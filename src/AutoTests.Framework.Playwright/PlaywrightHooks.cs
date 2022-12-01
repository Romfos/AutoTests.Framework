using BoDi;
using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Playwright;

[Binding]
public sealed class PlaywrightHooks
{
    [BeforeTestRun(Order = 1200)]
    public static async Task BeforeTestRun(IObjectContainer objectContainer)
    {
        var browserTypeLaunchOptions = objectContainer.IsRegistered<BrowserTypeLaunchOptions>()
            ? objectContainer.Resolve<BrowserTypeLaunchOptions>()
            : new BrowserTypeLaunchOptions { Headless = false };

        Program.Main(new[] { "install" });
        var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);
        var page = await browser.NewPageAsync();

        objectContainer.RegisterInstanceAs(playwright);
        objectContainer.RegisterInstanceAs(browser);
        objectContainer.RegisterInstanceAs(page);
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
