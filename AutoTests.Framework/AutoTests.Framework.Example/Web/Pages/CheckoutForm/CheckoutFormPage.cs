using AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress;

namespace AutoTests.Framework.Example.Web.Pages.CheckoutForm
{
    public class CheckoutFormPage : BootstrapPage
    {
        public BillingAddressPage BillingAddress { get; }

        public CheckoutFormPage(Application application) : base(application)
        {
            BillingAddress = application.Web.GetPage<BillingAddressPage>();
        }
    }
}