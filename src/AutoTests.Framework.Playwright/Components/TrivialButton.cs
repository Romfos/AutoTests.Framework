using AutoTests.Framework.Components.Contracts;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialButton : IClick
{
    private readonly IPage page;

    public string? Locator { get; set; }

    public TrivialButton(IPage page)
    {
        this.page = page;
    }

    public async Task ClickAsync()
    {
        if (Locator == null)
        {
            throw new Exception($"Locator is required");
        }

        await page.ClickAsync(Locator);
    }
}
