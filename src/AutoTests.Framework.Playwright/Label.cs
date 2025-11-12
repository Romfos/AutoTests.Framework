using AutoTests.Framework.Contracts;
using AutoTests.Framework.Options;
using AutoTests.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright;

public sealed class Label([FromKeyedServices] IComponentOptions options, IPage page) : IComponent, IGetValue<string?>, IVisible
{
    private readonly string locator = options.Get<string>();

    public async Task<string?> GetValueAsync()
    {
        var textContent = await page.Locator(locator).TextContentAsync();
        return textContent?.Trim();
    }

    public async Task<bool> IsVisibleAsync()
    {
        return await page.Locator(locator).IsVisibleAsync();
    }
}
