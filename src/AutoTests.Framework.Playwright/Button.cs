using AutoTests.Framework.Contracts;
using AutoTests.Framework.Options;
using AutoTests.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright;

public sealed class Button([ServiceKey] string path, IOptionsService optionsService, IPage page) : IComponent, IClick, IVisible, IEnabled
{
    private readonly string locator = optionsService.GetOptions<string>(path);

    public async Task ClickAsync()
    {
        await page.ClickAsync(locator);
    }

    public async Task<bool> IsVisibleAsync()
    {
        return await page.Locator(locator).IsVisibleAsync();
    }

    public async Task<bool> IsEnabledAsync()
    {
        return await page.Locator(locator).IsEnabledAsync();
    }
}
