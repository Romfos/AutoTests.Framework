using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Boostrap.Tests.Web
{
    public class WebDriverFactory
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

        public static void Dispose()
        {
            webDriver?.Dispose();
        }

        private static IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
    }
}
