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
            webDriver = new ChromeDriver();
        }

        public static void Stop()
        {
            webDriver?.Dispose();
        }
    }
}
