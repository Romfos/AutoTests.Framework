using AutoTests.Framework.Models;
using AutoTests.Framework.Models.PropertyAttributes;

namespace AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress
{
    public class BillingAddressModel : Model
    {
        [Name("First name")]
        public string FirstName { get; set; }

        [Name("Last name")]
        public string LastName { get; set; }
    }
}