using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Boostrap.Tests.Web;

public class PlaywrightFactory
{
	private static IPlaywright playwright;
	private static IBrowser browser;
	private static IPage page;

	public static IPage GetPage()
	{
		return page;
	}

	public static async Task StartAsync()
	{
		Program.Main(new[] { "install" });
		playwright = await Playwright.CreateAsync();
		browser = await playwright.Chromium.LaunchAsync();
		page = await browser.NewPageAsync();
	}

	public static async Task StopAsync()
	{
		await browser.DisposeAsync();
		playwright.Dispose();
	}
}
