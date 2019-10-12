using AutoTests.Framework.PreProcessor;
using OpenQA.Selenium;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Boostrap.Tests.Steps
{
    [Binding]
    public class CommonSteps
    {
        private readonly IWebDriver webDriver;

        public CommonSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        [Given(@"navigate to '(.*)'")]
        public async Task GivenNavigateTo(IExpression expression)
        {
            var url = await expression.ExecuteAsync<string>();
            webDriver.Navigate().GoToUrl(url);
        }
    }
}
