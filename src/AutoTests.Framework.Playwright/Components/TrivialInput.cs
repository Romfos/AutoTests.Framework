using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.Playwright.Components;

public sealed class TrivialInput : ISetValue, IGetValue
{
    private readonly IPage page;

    public string? Locator { get; set; }

    public TrivialInput(IPage page)
    {
        this.page = page;
    }

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
}
