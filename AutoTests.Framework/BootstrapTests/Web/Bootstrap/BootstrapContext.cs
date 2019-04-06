using OpenQA.Selenium;

namespace BootstrapTests.Web.Bootstrap
{
    public class BootstrapContext : Context
    {
        public BootstrapContext(Application application) : base(application)
        {
        }

        public void SetValue(string locator, string value)
        {
            WebDriver.FindElement(By.XPath(locator)).SendKeys(value);
        }

        public string GetValue(string locator)
        {
            return WebDriver.FindElement(By.XPath(locator)).GetAttribute("value");
        }
    }
}
