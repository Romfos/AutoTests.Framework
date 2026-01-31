namespace AutoTests.Framework.Playwright.AI.Options;

public interface IOptionsService
{
    Task<string> GetOptionsAsync(string path);
}
