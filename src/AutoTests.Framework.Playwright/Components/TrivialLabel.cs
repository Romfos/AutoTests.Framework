using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialLabel(IPage page) : IGetValue, IVisible
{
    [FromSelector]
    public required string Locator { get; init; }

    public async Task<object?> GetValueAsync()
    {
        var textContent = await page.TextContentAsync(Locator);
        return textContent?.Trim();
    }

    public async Task<bool> IsVisibleAsync()
    {
        return await page.Locator(Locator).IsVisibleAsync();
    }
}
