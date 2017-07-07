using System;
using AutoTests.Framework.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTests.Web
{
    public class ChromeDriverFactory : IWebDriverFactory, IDisposable
    {
        private readonly IWebDriver driver;

        public ChromeDriverFactory()
        {
            driver = new ChromeDriver();
        }

        public IWebDriver CreateWebDriver()
        {
            return driver;
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}