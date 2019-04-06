using OpenQA.Selenium;

namespace BootstrapTests.Web
{
    public abstract class Context
    {
        protected IWebDriver WebDriver => WebDriverProvider.GetWebDriver();

        protected Application Application { get; }

        protected Context(Application application)
        {
            Application = application;
        }
    }
}
