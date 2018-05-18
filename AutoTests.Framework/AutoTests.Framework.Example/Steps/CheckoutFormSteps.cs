using AutoTests.Framework.Example.Web.Extensions;
using AutoTests.Framework.Example.Web.Pages.CheckoutForm;
using AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress;
using AutoTests.Framework.Example.Web.Pages.CheckoutForm.YourCart;
using AutoTests.Framework.Models.Extensions;
using AutoTests.Framework.Web.Common.Extensions;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Example.Steps
{
    [Binding]
    public class CheckoutFormSteps : Steps
    {
        public CheckoutFormSteps(Application application) : base(application)
        {
        }

        [When(@"set following valus in Billing address from on Checkout form page:")]
        public void SetFollowingValusInBillingAddressFromOnCheckoutFormPage(BillingAddressModel model)
        {
            application.Web.GetPage<CheckoutFormPage>().BillingAddress.BindBillingAddressModel().SetValues(model);
        }

        [When(@"click Continue to checkout button on Checkout form page")]
        public void ClickContinueToCheckoutButtonOnCheckoutFormPage()
        {
            application.Web.GetPage<CheckoutFormPage>().ContinueToCheckout.Click();
        }

        [Then(@"following values should be present in Billing address from on Checkout form page:")]
        public void FollowingValuesShouldBePresentInBillingAddressFromOnCheckoutFormPage(BillingAddressModel expectedModel)
        {
            var actualModel = application.Web.GetPage<CheckoutFormPage>().BillingAddress
                .BindBillingAddressModel().GetValues(expectedModel);

            Assert.AreModelEqual(expectedModel, actualModel, "Incorrect values in Billing address from on Checkout form page");
        }

        [Then(@"following values should be present in Your cart list on Checkout form page:")]
        public void FollowingValuesShouldBePresentInYourCartListOnCheckoutFormPage(YourCartModel expectedModel)
        {
            var actualModels = application.Web.GetPage<CheckoutFormPage>().YourCart.GetModels(expectedModel);

            Assert.AreContainModel(expectedModel, actualModels, "Expected item not found in Your cart list on Checkout form page");
        }

        [Then(@"following validation messages should be present in Billing address from on Checkout form page:")]
        public void FollowingValidationMessagesShouldBePresentInBillingAddressFromOnCheckoutFormPage(
            BillingAddressModel expectedModel)
        {
            var actualModel = application.Web.GetPage<CheckoutFormPage>().BillingAddress
                .BindBillingAddressModel().GetValidationMessages(expectedModel);

            Assert.AreModelEqual(expectedModel, actualModel, 
                "Incorrect validation messages in Billing address from on Checkout form page");
        }
    }
}