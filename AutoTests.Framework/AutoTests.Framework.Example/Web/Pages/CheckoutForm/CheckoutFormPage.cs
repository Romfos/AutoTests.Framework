using AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress;
using AutoTests.Framework.Example.Web.Pages.CheckoutForm.YourCart;

namespace AutoTests.Framework.Example.Web.Pages.CheckoutForm
{
    public class CheckoutFormPage : BootstrapPage
    {
        public BillingAddressForm BillingAddress { get; }

        public YourCartList YourCart { get; set; }

        public CheckoutFormPage(Application application) : base(application)
        {
            BillingAddress = application.Web.GetPage<BillingAddressForm>();
        }
    }
}