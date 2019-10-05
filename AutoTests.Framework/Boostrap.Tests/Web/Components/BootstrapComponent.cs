using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Services;
using OpenQA.Selenium;

namespace Boostrap.Tests.Web.Components
{
    public abstract class BootstrapComponent : Component
    {
        protected IWebDriver WebDriver { get; }

        protected BootstrapComponent(ComponentService componentService, IWebDriver webDriver) 
            : base(componentService)
        {
            WebDriver  = webDriver;
        }
    }
}
