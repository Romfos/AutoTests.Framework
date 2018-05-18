using AutoTests.Framework.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTests.Framework.Example.Web
{
    public class ChromeDriverProvider : IWebDriverProvider
    {
        private static ChromeDriver chromeDriver;

        public IWebDriver GetWebDriver()
        {
            return chromeDriver;
        }

        public static void Start()
        {
            var options = new ChromeOptions();
            options.AddArgument("--window-size=1280,720");
            chromeDriver = new ChromeDriver(options);
        }

        public static void Stop()
        {
            chromeDriver?.Dispose();
        }
    }
}