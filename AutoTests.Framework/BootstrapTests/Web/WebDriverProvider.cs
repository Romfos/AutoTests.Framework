using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BootstrapTests.Web
{
    public class WebDriverProvider
    {
        private static IWebDriver webDriver;

        public static IWebDriver GetWebDriver()
        {
            if(webDriver == null)
            {
                webDriver = CreateWebDriver();
            }
            return webDriver;
        }

        public static void Stop()
        {
            if(webDriver != null)
            {
                webDriver.Dispose();
                webDriver = null;
            }
        }

        private static IWebDriver CreateWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1280,720");
            var chromeDriver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
            return chromeDriver;
        }
    }
}
