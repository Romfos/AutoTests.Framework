using BoDi;
using System;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Components.Application;

internal sealed class ApplicationFactory
{
    public IApplication Create(Assembly[] assemblies, IObjectContainer objectContainer)
    {
        var applicationInterface = typeof(IApplication);

        var applicationTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract)
            .Where(applicationInterface.IsAssignableFrom)
            .ToList();

        if (applicationTypes.Count == 0)
        {
            throw new Exception("Unable to get application");
        }
        if (applicationTypes.Count > 1)
        {
            throw new Exception("Only one applciation is alloweed in test applciation");
        }

        return (IApplication)CreateInstance(applicationTypes.Single(), objectContainer);
    }

    private object CreateInstance(Type type, IObjectContainer objectContainer)
    {
        var constructors = type.GetConstructors();
        if (constructors.Length != 1)
        {
            throw new Exception($"type {type.FullName} should have single constructor");
        }

        var arguments = constructors.Single()
            .GetParameters()
            .Select(x => objectContainer.Resolve(x.ParameterType))
            .ToArray();

        var target = Activator.CreateInstance(type, arguments);
        if (target == null)
        {
            throw new Exception($"Unable to create {type.FullName}");
        }

        var properties = type.GetProperties().Where(x => x.GetCustomAttribute<Route>() != null);
        foreach (var property in properties)
        {
            property.SetValue(target, CreateInstance(property.PropertyType, objectContainer));
        }

        return target;
    }
}
