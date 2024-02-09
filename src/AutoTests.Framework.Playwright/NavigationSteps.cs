using AutoTests.Framework.Expressions;
using Microsoft.Playwright;
using Reqnroll;

namespace AutoTests.Framework.Playwright;

[Binding]
public sealed class NavigationSteps(IPage page)
{
    [Given(@"navigate to '([^']*)'")]
    public async Task GivenNavigateTo(ArgumentExpression expression)
    {
        var url = await expression.ExecuteAsync<string>();
        await page.GotoAsync(url);
    }

    [Then(@"page url should be '([^']*)'")]
    public async Task PageUrlShouldBe(ArgumentExpression expression)
    {
        var expected = await expression.ExecuteAsync<string>();
        await page.WaitForURLAsync(expected);
    }
}
