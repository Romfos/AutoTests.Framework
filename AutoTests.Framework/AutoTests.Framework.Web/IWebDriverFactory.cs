using OpenQA.Selenium;

namespace AutoTests.Framework.Web
{
    public interface IWebDriverFactory
    {
        IWebDriver CreateWebDriver();
    }
}