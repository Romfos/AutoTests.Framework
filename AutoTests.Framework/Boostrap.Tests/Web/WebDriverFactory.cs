using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Boostrap.Tests.Web
{
    public class WebDriverFactory
    {
        private static IWebDriver webDriver;

        public static IWebDriver GetWebDriver()
        {
            return webDriver;
        }

        public static void Start()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1280,720");
            webDriver = new ChromeDriver(chromeOptions);
        }

        public static void Stop()
        {
            webDriver?.Dispose();
        }
    }
}
