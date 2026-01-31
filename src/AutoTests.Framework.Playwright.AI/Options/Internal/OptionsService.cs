using AutoTests.Framework.Playwright.AI.Options;
using Microsoft.Extensions.AI;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright.AI.Options.Internal;

internal sealed class OptionsService(OptionsCache optionsCache, IPage page, IChatClient chatClient) : IOptionsService
{
    public async Task<string> GetOptionsAsync(string path)
    {
        var locator = optionsCache.GetOptionValue(path);
        if (locator != null)
        {
            return locator;
        }
        else
        {
            locator = await ExtractOptionsAsync(path);
            optionsCache.SaveOptionValue(path, locator);
            return locator;
        }
    }

    private async Task<string> ExtractOptionsAsync(string path)
    {
        var pageContent = await page.ContentAsync();

        var prompt =
            $"""
            # Htmp page content
            ```html
            {pageContent}
            ```

            Search element '{path}' on page.

            Respond as raw xpath locator for seached element only. Do not provide any additional text or explanation.
            """;

        var resposne = await chatClient.GetResponseAsync(prompt);
        return GetLocatorFromMarkdown(resposne.Text);
    }

    private string GetLocatorFromMarkdown(string locator)
    {
        return locator.Trim('`');
    }
}
