using System.Threading.Tasks;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.PreProcessor;
using OpenQA.Selenium;

namespace Boostrap.Tests.Web.Components.Shared
{
    public class InputComponent : BootstrapComponent, ISetValue, IEqualTo
    {
        [Primary]
        public string Locator { get; set; }

        public InputComponent(ComponentService componentService, IWebDriver webDriver)
            : base(componentService, webDriver)
        {
        }

        public async Task SetValue(IExpression expression)
        {
            var text = await expression.ExecuteAsync<string>();
            WebDriver.FindElement(By.CssSelector(Locator)).SendKeys(text);
        }

        public async Task<bool> EqualToAsync(IExpression expression)
        {
            var expected = await expression.ExecuteAsync<string>();

            var runtime = (IJavaScriptExecutor) WebDriver;
            var actual = runtime.ExecuteScript("return $(arguments[0]).val()", Locator).ToString();

            return expected == actual;
        }
    }
}
