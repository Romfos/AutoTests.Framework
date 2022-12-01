using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Data;

internal sealed class DataLoader
{
    public dynamic Load(Assembly[] assemblies)
    {
        var expandoObject = new ExpandoObject() as IDictionary<string, object?>;
        foreach (var jsonResource in assemblies.SelectMany(GetJsonResources))
        {
            expandoObject[jsonResource.Name] = ConvertToDynamicObject(jsonResource.JsonDocument.RootElement);
        }
        return expandoObject;
    }

    private dynamic? ConvertToDynamicObject(JsonElement jsonElement)
    {
        return jsonElement.ValueKind switch
        {
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            JsonValueKind.Undefined => null,
            JsonValueKind.Number => jsonElement.GetInt32(),
            JsonValueKind.String => jsonElement.GetString(),
            JsonValueKind.Array => jsonElement.EnumerateArray().Select(ConvertToDynamicObject).ToArray(),
            JsonValueKind.Object => ConvertObjectToDynamicObject(jsonElement),
            _ => throw new Exception("Unsupported json element in test data")
        };
    }

    private dynamic ConvertObjectToDynamicObject(JsonElement jsonElement)
    {
        var expandoObject = new ExpandoObject() as IDictionary<string, object?>;
        foreach (var element in jsonElement.EnumerateObject())
        {
            expandoObject[element.Name] = ConvertToDynamicObject(element.Value);
        }
        return expandoObject;
    }

    private IEnumerable<(string Name, JsonDocument JsonDocument)> GetJsonResources(Assembly assembly)
    {
        return assembly.GetManifestResourceNames()
            .Where(x => x.EndsWith(".json"))
            .Select(x => GetJsonResource(assembly, x));
    }

    private (string, JsonDocument) GetJsonResource(Assembly assembly, string resource)
    {
        var pattern = $"{assembly.GetName().Name}.Data.(.*).json";
        var regex = new Regex(pattern);
        var name = regex.Match(resource).Groups[1].Value;

        using var stream = assembly.GetManifestResourceStream(resource)!;
        using var streamReader = new StreamReader(stream);
        var content = streamReader.ReadToEnd();

        var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(content)!;

        return (name, jsonDocument);
    }
}
