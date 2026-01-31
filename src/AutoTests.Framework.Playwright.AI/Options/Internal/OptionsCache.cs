using System.Text.Json;

namespace AutoTests.Framework.Playwright.AI.Options.Internal;

internal sealed class OptionsCache(FileInfo file, Dictionary<string, string> options) : IAsyncDisposable
{
    public static OptionsCache Create(FileInfo file)
    {
        if (file.Exists)
        {
            var optionsJson = File.ReadAllText(file.FullName);
            var options = JsonSerializer.Deserialize<Dictionary<string, string>>(optionsJson)!;
            return new OptionsCache(file, options);
        }
        else
        {
            return new OptionsCache(file, []);
        }
    }

    public string? GetOptionValue(string key)
    {
        return options.TryGetValue(key, out var value) ? value : null;
    }

    public void SaveOptionValue(string key, string value)
    {
        options[key] = value;
    }

    public async ValueTask DisposeAsync()
    {
        var optionsJson = JsonSerializer.Serialize(options);
        await File.WriteAllTextAsync(file.FullName, optionsJson);
    }
}
