using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialButton : IClick, IVisible, IEnabled
{
    private readonly IPage page;

    [FromSelector]
    public string? Locator { get; set; }

    public TrivialButton(IPage page)
    {
        this.page = page;
    }

    public async Task ClickAsync()
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        await page.ClickAsync(Locator);
    }

    public async Task<bool> IsVisibleAsync()
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        return await page.Locator(Locator).IsVisibleAsync();
    }

    public async Task<bool> IsEnabledAsync()
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        return await page.Locator(Locator).IsEnabledAsync();
    }
}
