using System;
using AutoTests.Framework.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTests.Framework.Example.Web
{
    public class ChromeDriverFactory : IWebDriverFactory, IDisposable
    {
        private readonly ChromeDriver chromeDriver;

        public ChromeDriverFactory()
        {
            var options = new ChromeOptions();
            options.AddArgument("--window-size=1280,720");
            chromeDriver = new ChromeDriver(options);
        }

        public IWebDriver CreateWebDriver()
        {
            return chromeDriver;
        }

        public void Dispose()
        {
            chromeDriver?.Dispose();
        }
    }
}