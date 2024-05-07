using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialButton(IPage page) : IClick, IVisible, IEnabled
{
    [FromSelector]
    public required string Locator { get; set; }

    public async Task ClickAsync()
    {
        await page.ClickAsync(Locator);
    }

    public async Task<bool> IsVisibleAsync()
    {
        return await page.Locator(Locator).IsVisibleAsync();
    }

    public async Task<bool> IsEnabledAsync()
    {
        return await page.Locator(Locator).IsEnabledAsync();
    }
}
