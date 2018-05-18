using AutoTests.Framework.Example.Web.Elements.BootstrapInput;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress
{
    public class BillingAddressForm : BootstrapPage
    {
        private Input FirstName { get; set; }
        private Input LastName { get; set; }

        public BillingAddressForm(Application application) : base(application)
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