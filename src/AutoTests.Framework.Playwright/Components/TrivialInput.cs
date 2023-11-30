using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialInput(IPage page) : ISetValue, IGetValue, IVisible, IEnabled
{
    [FromSelector]
    public string? Locator { get; set; }

    public async Task<object?> GetValueAsync()
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        return await page.InputValueAsync(Locator);
    }

    public async Task SetValueAsync(ArgumentExpression expression)
    {
        if (Locator == null)
        {
            throw new Exception("Locator is required");
        }

        var value = await expression.ExecuteAsync<string>();
        await page.FillAsync(Locator, value);
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
