using System.Dynamic;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Data;

internal sealed partial class DataLoader
{
    [GeneratedRegex("(.*).Data.(.*).json")]
    private static partial Regex JsonDataResourceRegex();

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
            .Select(x => JsonDataResourceRegex().Match(x))
            .Where(x => x.Success)
            .Select(x => GetJsonResource(assembly, x));
    }

    private (string, JsonDocument) GetJsonResource(Assembly assembly, Match match)
    {
        var resource = match.Groups[0].Value;
        var name = match.Groups[2].Value;

        using var stream = assembly.GetManifestResourceStream(resource)!;
        using var streamReader = new StreamReader(stream);
        var content = streamReader.ReadToEnd();

        var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(content)!;

        return (name, jsonDocument);
    }
}
