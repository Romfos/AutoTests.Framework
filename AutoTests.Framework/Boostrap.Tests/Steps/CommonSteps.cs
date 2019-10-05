using OpenQA.Selenium;
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
        public void GivenNavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
    }
}
