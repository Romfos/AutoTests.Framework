using System;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Components.Application;

public sealed class ComponentService
{
    private readonly IApplication application;

    public ComponentService(IApplication application)
    {
        this.application = application;
    }

    public T GetComponent<T>(string path)
        where T : class
    {
        var component = path
            .Split(new[] { ">" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Aggregate((object)application, GetRouteComponent);

        if (component is not T result)
        {
            throw new Exception($"Component by path {path} do not implement contract {typeof(T).FullName}");
        }

        return result;
    }

    private object GetRouteComponent(object component, string routeName)
    {
        var type = component.GetType();

        var properties = type
            .GetProperties()
            .Where(x => string.Equals(x.GetCustomAttribute<Route>()?.Name, routeName, StringComparison.InvariantCultureIgnoreCase))
            .ToList();

        if (properties.Count == 0)
        {
            throw new Exception($"Unable to get route {routeName} from type {type.FullName}");
        }

        if (properties.Count > 1)
        {
            throw new Exception($"Type {type.FullName} has several properties wthi the same route {routeName}");
        }

        var property = properties.Single();
        var routeComponent = property.GetValue(component);

        return routeComponent ?? throw new Exception($"Property {property.Name} in {type.FullName} is null");
    }
}
