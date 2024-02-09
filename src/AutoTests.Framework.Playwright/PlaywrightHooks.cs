using BoDi;
using Microsoft.Playwright;
using Reqnroll;

namespace AutoTests.Framework.Playwright;

[Binding]
public sealed class PlaywrightHooks
{
    [BeforeTestRun(Order = 1200)]
    public static async Task BeforeTestRun(IObjectContainer objectContainer)
    {
        var browserTypeLaunchOptions = objectContainer.IsRegistered<BrowserTypeLaunchOptions>()
            ? objectContainer.Resolve<BrowserTypeLaunchOptions>()
            : new BrowserTypeLaunchOptions { Headless = true };

        Program.Main(new[] { "install" });
        var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);

        objectContainer.RegisterInstanceAs(playwright);
        objectContainer.RegisterInstanceAs(browser);
    }

    [BeforeScenario(Order = 1000)]
    public static async Task BeforeScenario(IObjectContainer objectContainer)
    {
        var browser = objectContainer.Resolve<IBrowser>();
        var page = await browser.NewPageAsync();
        objectContainer.RegisterInstanceAs(page);
    }

    [AfterScenario(Order = 1000)]
    public static async Task AfterScenario(IObjectContainer objectContainer)
    {
        await objectContainer.Resolve<IPage>().CloseAsync();
    }

    [AfterTestRun(Order = 1200)]
    public static async Task AfterTestRun(IObjectContainer objectContainer)
    {
        var browser = objectContainer.Resolve<IBrowser>();
        var playwright = objectContainer.Resolve<IPlaywright>();

        await browser.DisposeAsync();
        playwright.Dispose();
    }
}
