using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialLabel : IGetValue, IVisible
{
    private readonly IPage page;

    [FromSelector]
    public string? Locator { get; set; }

    public TrivialLabel(IPage page)
    {
        this.page = page;
    }

    public async Task<object?> GetValueAsync()
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        var textContent = await page.TextContentAsync(Locator);
        return textContent?.Trim();
    }

    public async Task<bool> IsVisibleAsync()
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        return await page.Locator(Locator).IsVisibleAsync();
    }
}
