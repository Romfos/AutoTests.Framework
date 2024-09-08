using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;

namespace AutoTests.Framework.Playwright;

[Binding]
public sealed class PlaywrightHooks
{
    [BeforeTestRun(Order = 1200)]
    public static async Task BeforeTestRun(ObjectContainer objectContainer)
    {
        var browserTypeLaunchOptions = objectContainer.IsRegistered<BrowserTypeLaunchOptions>()
            ? objectContainer.Resolve<BrowserTypeLaunchOptions>()
            : new BrowserTypeLaunchOptions { Headless = true };

        Program.Main(["install", "chromium"]);

        IPlaywright playwright;
        if (objectContainer.IsRegistered<IPlaywright>())
        {
            playwright = objectContainer.Resolve<IPlaywright>();
        }
        else
        {
            playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            objectContainer.RegisterInstanceAs(playwright);
        }

        if (!objectContainer.IsRegistered<IBrowser>())
        {
            var browser = await playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);
            objectContainer.RegisterInstanceAs(browser);
        }
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
