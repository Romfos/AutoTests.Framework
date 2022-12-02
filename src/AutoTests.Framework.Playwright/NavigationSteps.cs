using AutoTests.Framework.Expressions;
using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Playwright;

[Binding]
public sealed class NavigationSteps
{
    private readonly IPage page;

    public NavigationSteps(IPage page)
    {
        this.page = page;
    }

    [Given(@"navigate to '([^']*)'")]
    public async Task GivenNavigateTo(IExpression expression)
    {
        var url = await expression.ExecuteAsync<string>();
        await page.GotoAsync(url);
    }
}