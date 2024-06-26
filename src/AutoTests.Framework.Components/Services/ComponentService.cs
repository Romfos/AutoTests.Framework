using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Attributes;
using System.Reflection;

namespace AutoTests.Framework.Components.Services;

public sealed class ComponentService(IApplication application)
{
    private readonly IApplication application = application;

    public T GetComponent<T>(string path)
        where T : class
    {
        var component = path
            .Split([">"], StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Aggregate((object)application, GetRouteComponent);

        if (component is not T result)
        {
            throw new Exception($"Component by path '{path}' do not implement contract '{typeof(T).FullName}'");
        }

        return result;
    }

    private object GetRouteComponent(object component, string routeName)
    {
        var type = component.GetType();

        var properties = type
            .GetProperties()
            .Where(x => string.Equals(x.GetCustomAttribute<RouteAttribute>()?.Name, routeName, StringComparison.InvariantCultureIgnoreCase))
            .ToList();

        if (properties is [])
        {
            throw new Exception($"Unable to get route '{routeName}' from type '{type.FullName}'");
        }

        if (properties is not [var property])
        {
            throw new Exception($"Type '{type.FullName}' has several properties with the same route '{routeName}'");
        }

        var routeComponent = property.GetValue(component);

        return routeComponent ?? throw new Exception($"Property '{property.Name}' in '{type.FullName}' is null");
    }
}
