using BoDi;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace AutoTests.Framework.Components.Application;

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

        if (applicationTypes.Count == 0)
        {
            throw new Exception("Unable to get application");
        }
        if (applicationTypes.Count > 1)
        {
            throw new Exception("Only one applciation is alloweed in test applciation");
        }

        return (IApplication)CreateComponent(applicationTypes.Single(), objectContainer);
    }

    private object CreateComponent(Type componentType, IObjectContainer objectContainer)
    {
        var constructors = componentType.GetConstructors();
        if (constructors.Length != 1)
        {
            throw new Exception($"type {componentType.FullName} should have single constructor");
        }

        var arguments = constructors.Single()
            .GetParameters()
            .Select(x => objectContainer.Resolve(x.ParameterType))
            .ToArray();

        var component = Activator.CreateInstance(componentType, arguments);
        if (component == null)
        {
            throw new Exception($"Unable to create {componentType.FullName}");
        }

        var properties = componentType.GetProperties().Where(x => x.GetCustomAttribute<Route>() != null);
        foreach (var property in properties)
        {
            property.SetValue(component, CreateComponent(property.PropertyType, objectContainer));
        }

        if (GetComponentJson(componentType) is JsonElement jsonElement)
        {
            PatchComponent(componentType, component, jsonElement);
        }

        return component;
    }

    private void PatchComponent(Type componentType, object component, JsonElement jsonElement)
    {
        if (jsonElement.ValueKind != JsonValueKind.Object)
        {
            throw new Exception($"Inavlid json data for component {componentType.FullName}: {jsonElement}");
        }

        foreach (var jsonProperty in jsonElement.EnumerateObject())
        {
            PatchComponentProperty(componentType, component, jsonProperty.Name, jsonProperty.Value);
        }
    }

    private void PatchComponentProperty(Type componentType, object component, string name, JsonElement jsonElement)
    {
        var property = componentType.GetProperty(name);
        if (property == null)
        {
            throw new Exception($"Unable to find property {name} in {componentType.FullName}");
        }

        if (jsonElement.ValueKind == JsonValueKind.Object)
        {
            var propertyValue = property.GetValue(component);
            if (propertyValue == null)
            {
                throw new Exception($"Unable to get sub compoent {name}");
            }
            PatchComponent(property.PropertyType, propertyValue, jsonElement);
        }
        else
        {
            property.SetValue(component, jsonElement.Deserialize(property.PropertyType));
        }
    }

    private JsonElement? GetComponentJson(Type componentType)
    {
        return resources.GetOrAdd(componentType, LoadComponentJson)?.RootElement;
    }

    private JsonDocument? LoadComponentJson(Type componentType)
    {
        using var stream = componentType.Assembly.GetManifestResourceStream(componentType.FullName + ".json");
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
