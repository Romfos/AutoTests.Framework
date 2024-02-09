using AutoTests.Framework.Expressions;
using Reqnroll;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoTests.Framework.Models;

internal sealed class Model(IExpressionService expressionService, Table table) : IModel
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public async Task<T> GetValueAsync<T>()
    {
        var properties = table.Rows.ToDictionary(x => x["Name"], x => x["Value"]);
        return await ConvertToObject<T>(properties);
    }

    public async IAsyncEnumerable<T> GetValuesAsync<T>()
    {
        foreach (var row in table.Rows)
        {
            yield return await ConvertToObject<T>(row);
        }
    }

    private async Task<T> ConvertToObject<T>(IEnumerable<KeyValuePair<string, string>> data)
    {
        var properties = new Dictionary<string, object?>();

        foreach (var keyValuePair in data)
        {
            var name = keyValuePair.Key;
            var value = keyValuePair.Value;
            var propertyName = await expressionService.ExecuteAsync<string>(name);
            var propertyValue = await expressionService.ExecuteAsync<object?>(value);
            properties[propertyName] = propertyValue;
        }

        return ConvertToObject<T>(properties);
    }

    private T ConvertToObject<T>(Dictionary<string, object?> properties)
    {
        var jsonModel = JsonSerializer.Serialize(properties);
        var result = JsonSerializer.Deserialize<T>(jsonModel, jsonSerializerOptions) ?? throw new Exception($"Unable to serialize {typeof(T).FullName}");
        return result;
    }
}
