using AutoTests.Framework.Playwright.AI.Options;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright.AI.Steps.Internal;

internal sealed class PlaywrightSteps(IPage page, IOptionsService optionsService)
{
    [Given(@"navigate to '([^']*)'")]
    public async Task Navigate(string url)
    {
        await page.GotoAsync(url);
    }

    [Then(@"page url should be '([^']*)'")]
    public async Task PageUrlShouldBe(string url)
    {
        await page.WaitForURLAsync(url);
    }

    [When("click on '(.*)'")]
    public async Task ClickStep(string path)
    {
        var selector = await optionsService.GetOptionsAsync(path);
        await page.Locator(selector).ClickAsync();
    }

    [When(@"set following values:")]
    public async Task WhenSetFollowingValuesToFields(string[][] values)
    {
        foreach (var (path, value) in values.AsNameValueTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);
            await page.Locator(selector).FillAsync(value);
        }
    }

    [Then(@"inputs should have following values:")]
    public async Task ThenInputsShouldHaveFollowingValues(string[][] values)
    {
        var errors = new List<string>();

        foreach (var (path, expected) in values.AsNameValueTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);
            var actual = await page.Locator(selector).InputValueAsync();

            if ((expected, actual) is (null, not null) or (not null, null)
                || expected != null && !expected.Equals(actual))
            {
                errors.Add($"Path '{path}'. Actual '{actual}'. Expected: '{expected}'");
            }
        }

        if (errors.Any())
        {
            throw new Exception($"Some components have unexpected values: {string.Join(Environment.NewLine, errors)}");
        }
    }

    [Then(@"should have following values:")]
    public async Task ThenLabelsShouldHaveFollowingValues(string[][] values)
    {
        var errors = new List<string>();

        foreach (var (path, expected) in values.AsNameValueTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);
            var actual = await page.Locator(selector).TextContentAsync();
            actual = actual?.Trim();

            if ((expected, actual) is (null, not null) or (not null, null)
                || expected != null && !expected.Equals(actual))
            {
                errors.Add($"Path '{path}'. Actual '{actual}'. Expected: '{expected}'");
            }
        }

        if (errors.Any())
        {
            throw new Exception($"Some components have unexpected values: {string.Join(Environment.NewLine, errors)}");
        }
    }

    [Then(@"should be visible:")]
    public async Task ThenShouldBeVisible(string[][] values)
    {
        var errors = new List<string>();

        foreach (var path in values.AsSingleColumnNameTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);

            if (!await page.Locator(selector).IsVisibleAsync())
            {
                errors.Add(path);
            }
        }

        if (errors.Any())
        {
            throw new Exception($"Some components are invisible: {string.Join(",", errors)}");
        }
    }

    [Then(@"should be invisible:")]
    public async Task ThenShouldBeInvisible(string[][] values)
    {
        var errors = new List<string>();

        foreach (var path in values.AsSingleColumnNameTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);

            if (await page.Locator(selector).IsVisibleAsync())
            {
                errors.Add(path);
            }
        }

        if (errors.Any())
        {
            throw new Exception($"Some components are visible: {string.Join(",", errors)}");
        }
    }

    [Then(@"should be enabled:")]
    public async Task ThenShouldBeEnabled(string[][] values)
    {
        var errors = new List<string>();

        foreach (var path in values.AsSingleColumnNameTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);

            if (!await page.Locator(selector).IsEnabledAsync())
            {
                errors.Add(path);
            }
        }

        if (errors.Any())
        {
            throw new Exception($"Some components are disabled: {string.Join(",", errors)}");
        }
    }

    [Then(@"should be disabled:")]
    public async Task ThenShouldBeDisabled(string[][] values)
    {
        var errors = new List<string>();

        foreach (var path in values.AsSingleColumnNameTable())
        {
            var selector = await optionsService.GetOptionsAsync(path);

            if (await page.Locator(selector).IsEnabledAsync())
            {
                errors.Add(path);
            }
        }

        if (errors.Any())
        {
            throw new Exception($"Some components are enabled: {string.Join(",", errors)}");
        }
    }
}
