using System.Threading.Tasks;
using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using OpenQA.Selenium;

namespace Boostrap.Tests.Web.Components.Shared
{
    public class ButtonComponent : BootstrapComponent, IClick
    {
        [Primary]
        public string Locator { get; set; }

        public ButtonComponent(ComponentService componentService, IWebDriver webDriver) 
            : base(componentService, webDriver)
        {
        }

        public async Task ClickAsync()
        {
            WebDriver.FindElement(By.CssSelector(Locator)).Click();
        }
    }
}
