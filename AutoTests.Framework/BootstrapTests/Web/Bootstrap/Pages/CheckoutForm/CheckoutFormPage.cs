using AutoTests.Framework.PageObjects.Provider.Attributes;
using BootstrapTests.Web.Bootstrap.Elements.BootstrapInput;

namespace BootstrapTests.Web.Bootstrap.Pages.CheckoutForm
{
    [PageObjectName("checkout form")]
    public class CheckoutFormPage : BootstrapPage
    {
        [PageObjectName("first name")]
        public BootstrapInputElement FirstName { get; set; }

        [PageObjectName("last name")]
        public BootstrapInputElement LastName { get; set; }

        public CheckoutFormPage(Application application) : base(application)
        {
        }
    }
}
