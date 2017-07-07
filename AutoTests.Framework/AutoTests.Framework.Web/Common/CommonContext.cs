using AutoTests.Framework.Web.Common.Scripts;
using OpenQA.Selenium;

namespace AutoTests.Framework.Web.Common
{
    public class CommonContext : Context
    {
        protected IWebDriver Driver { get; }

        public JavaScripts JavaScripts { get; }

        public CommonContext(WebDependencies dependencies)
        {
            Driver = dependencies.WebDriverFactory.CreateWebDriver();
            JavaScripts = dependencies.GetScriptLibrary<JavaScripts>();
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public void Back()
        {
            Driver.Navigate().Back();
        }

        public void Forward()
        {
            Driver.Navigate().Forward();
        }

        public void Click(string locator)
        {
            Driver.FindElement(By.XPath(locator)).Click();
        }

        public void SetValue(string locator, string value)
        {
            Driver.FindElement(By.XPath(locator)).SendKeys(value);
        }

        public string GetAttribute(string locator, string attributeName)
        {
            return Driver.FindElement(By.XPath(locator)).GetAttribute(attributeName);
        }

        public void Submit(string locator)
        {
            Driver.FindElement(By.XPath(locator)).Submit();
        }

        public string GetTitle()
        {
            return Driver.Title;
        }

        public bool IsEnabled(string locator)
        {
            return Driver.FindElement(By.XPath(locator)).Enabled;
        }

        public bool IsSelected(string locator)
        {
            return Driver.FindElement(By.XPath(locator)).Selected;
        }

        public string GetText(string locator)
        {
            return Driver.FindElement(By.XPath(locator)).Text;
        }

        public bool IsDisplayed(string locator)
        {
            return Driver.FindElement(By.XPath(locator)).Displayed;
        }

        public void Clear(string locator)
        {
            Driver.FindElement(By.XPath(locator)).Clear();
        }

        public object Execute(string script, params object[] args)
        {
            return ((IJavaScriptExecutor) Driver).ExecuteScript(script, args);
        }
    }
}