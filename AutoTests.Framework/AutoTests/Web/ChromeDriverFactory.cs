using AutoTests.Framework.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTests.Web
{
    public class ChromeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
    }
}