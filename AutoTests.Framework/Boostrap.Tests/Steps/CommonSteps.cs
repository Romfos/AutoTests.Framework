using AutoTests.Framework.PreProcessor;
using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Boostrap.Tests.Steps;

[Binding]
public class CommonSteps
{
    private readonly IPage page;

    public CommonSteps(IPage page)
    {
        this.page = page;
    }

    [Given(@"navigate to '(.*)'")]
    public async Task GivenNavigateTo(IExpression expression)
    {
        var url = await expression.ExecuteAsync<string>();
        await page.GotoAsync(url);
    }
}
