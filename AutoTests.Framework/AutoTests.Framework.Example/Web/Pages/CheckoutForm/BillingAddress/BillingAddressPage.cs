using AutoTests.Framework.Web.Binding;
using AutoTests.Framework.Web.Common.Elements;

namespace AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress
{
    public class BillingAddressPage : BootstrapPage
    {
        private Input FirstName { get; set; }
        private Input LastName { get; set; }

        public BillingAddressPage(Application application) : base(application)
        {
        }

        public Binder<BillingAddressModel> BindBillingAddressModel()
        {
            return new Binder<BillingAddressModel>()
                .Bind(x => x.FirstName, FirstName)
                .Bind(x => x.LastName, LastName);
        }
    }
}