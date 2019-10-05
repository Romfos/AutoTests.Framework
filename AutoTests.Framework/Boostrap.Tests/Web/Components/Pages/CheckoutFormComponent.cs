using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using Boostrap.Tests.Web.Components.Shared;
using OpenQA.Selenium;

namespace Boostrap.Tests.Web.Components.Pages
{
    [Route("Checkout form")]
    public class CheckoutFormComponent : BootstrapComponent
    {
        [Route("First name")]
        public InputComponent FirstName { get; set; }

        [Route("Last name")]
        public InputComponent LastName { get; set; }

        [Route("Continue to checkout")]
        public ButtonComponent ContinueToCheckout { get; set; }

        public CheckoutFormComponent(ComponentService componentService, IWebDriver webDriver)
            : base(componentService, webDriver)
        {
        }
    }
}
