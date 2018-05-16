using OpenQA.Selenium;

namespace AutoTests.Framework.Web
{
    public interface IWebDriverProvider
    {
        IWebDriver GetWebDriver();
    }
}