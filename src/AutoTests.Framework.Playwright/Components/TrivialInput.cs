using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialInput(IPage page) : ISetValue, IGetValue, IVisible, IEnabled
{
    [FromSelector]
    public required string Locator { get; set; }

    public async Task<object?> GetValueAsync()
    {
        return await page.InputValueAsync(Locator);
    }

    public async Task SetValueAsync(ArgumentExpression expression)
    {
        var value = await expression.ExecuteAsync<string>();
        await page.FillAsync(Locator, value);
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
