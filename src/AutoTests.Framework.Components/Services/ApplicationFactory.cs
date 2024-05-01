using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Attributes;
using BoDi;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;

namespace AutoTests.Framework.Components.Services;

internal sealed class ApplicationFactory
{
    private static readonly ConcurrentDictionary<Type, JsonDocument?> resources = new();

    public IApplication Create(Assembly[] assemblies, IObjectContainer objectContainer)
    {
        var applicationInterface = typeof(IApplication);

        var applicationTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract)
            .Where(applicationInterface.IsAssignableFrom)
            .ToList();

        if (applicationTypes is [])
        {
            throw new Exception("Unable to get application");
        }
        if (applicationTypes is not [var applicationType])
        {
            throw new Exception("Only one application is allowed in test application");
        }

        return (IApplication)CreateComponent(applicationType, objectContainer);
    }

    private object CreateComponent(Type componentType, IObjectContainer objectContainer)
    {
        var constructors = componentType.GetConstructors();
        if (constructors is not [var constructor])
        {
            throw new Exception($"Type {componentType.FullName} should have single constructor");
        }

        var arguments = constructor
            .GetParameters()
            .Select(x => objectContainer.Resolve(x.ParameterType))
            .ToArray();

        if (Activator.CreateInstance(componentType, arguments) is not object component)
        {
            throw new Exception($"Unable to create {componentType.FullName}");
        }

        var propertiesWithRouteAttribute = componentType.GetProperties().Where(x => x.GetCustomAttribute<RouteAttribute>() != null);
        foreach (var property in propertiesWithRouteAttribute)
        {
            property.SetValue(component, CreateComponent(property.PropertyType, objectContainer));
        }

        if (GetComponentJson(componentType) is JsonElement jsonElement)
        {
            PatchComponent(componentType, component, jsonElement);
        }

        var propertiesWithSelectorAttribute = componentType.GetProperties().Where(x => x.GetCustomAttribute<SelectorAttribute>() != null);
        foreach (var property in propertiesWithSelectorAttribute)
        {
            SetSelectorPropertyValue(property, component);
        }

        return component;
    }

    private void PatchComponent(Type componentType, object component, JsonElement jsonElement)
    {
        if (jsonElement.ValueKind != JsonValueKind.Object)
        {
            throw new Exception($"Invalid json data for component {componentType.FullName}: {jsonElement}");
        }

        foreach (var jsonProperty in jsonElement.EnumerateObject())
        {
            PatchComponentProperty(componentType, component, jsonProperty.Name, jsonProperty.Value);
        }
    }

    private void PatchComponentProperty(Type componentType, object component, string name, JsonElement jsonElement)
    {
        if (componentType.GetProperty(name) is not PropertyInfo property)
        {
            throw new Exception($"Unable to find property {name} in {componentType.FullName}");
        }

        if (jsonElement.ValueKind == JsonValueKind.Object)
        {
            var propertyValue = property.GetValue(component);
            if (propertyValue == null)
            {
                throw new Exception($"Unable to get sub component {name}");
            }
            PatchComponent(property.PropertyType, propertyValue, jsonElement);
        }
        else
        {
            property.SetValue(component, jsonElement.Deserialize(property.PropertyType));
        }
    }

    private void SetSelectorPropertyValue(PropertyInfo property, object component)
    {
        var selectorValue = property.GetCustomAttribute<SelectorAttribute>()!.Value;

        if (property.GetValue(component) is not object childComponent)
        {
            throw new Exception($"Unable to setup selector because of null {property.DeclaringType!.FullName}.{property.Name}");
        }

        var childComponentType = childComponent.GetType();
        var fromSelectorProperties = childComponentType
            .GetProperties()
            .Where(x => x.GetCustomAttribute<FromSelectorAttribute>() != null).ToList();

        if (fromSelectorProperties.Count == 0)
        {
            throw new Exception($"One property must have {nameof(FromSelectorAttribute)} attribute on property in type {childComponentType.FullName}");
        }
        if (fromSelectorProperties.Count > 1)
        {
            throw new Exception($"Only one property should have {nameof(FromSelectorAttribute)} attribute on property in type {childComponentType.FullName}");
        }

        fromSelectorProperties.Single().SetValue(childComponent, selectorValue);
    }

    private JsonElement? GetComponentJson(Type componentType)
    {
        return resources.GetOrAdd(componentType, LoadComponentJson)?.RootElement;
    }

    private JsonDocument? LoadComponentJson(Type componentType)
    {
        using var stream = componentType.Assembly.GetManifestResourceStream($"{componentType.FullName}.json");
        if (stream == null)
        {
            return null;
        }
        using var streamReader = new StreamReader(stream);

        var content = streamReader.ReadToEnd();
        var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(content)!;

        return jsonDocument;
    }
}
