using AutoTests.Framework.Web;
using OpenQA.Selenium;

namespace AutoTests.Web
{
    public class SemanticContext : Context
    {
        private readonly Application application;
        private readonly IWebDriver driver;

        public SemanticContext(Application application)
        {
            this.application = application;

            driver = application.Web.WebDriverFactory.CreateWebDriver();
        }

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Click(string locator)
        {
            driver.FindElement(By.XPath(locator)).Click();
        }

        public void SetValue(string locator, string value)
        {
            driver.FindElement(By.XPath(locator)).SendKeys(value);
        }
    }
}