﻿using AutoTests.Framework.Example.Web.Pages.CheckoutForm;
using AutoTests.Framework.Example.Web.Pages.CheckoutForm.BillingAddress;
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
            application.Web.GetPage<CheckoutFormPage>().BillingAddress.BindBillingAddressModel().SetValue(model);
        }

        [Then(@"following values should be present in Billing address from on Checkout form page:")]
        public void FollowingValuesShouldBePresentInBillingAddressFromOnCheckoutFormPage(BillingAddressModel expectedModel)
        {
            var actualModel = application.Web.GetPage<CheckoutFormPage>().BillingAddress
                .BindBillingAddressModel().GetValue(expectedModel);

            Assert.AreModelEqual(expectedModel, actualModel, "Incorrect values in Billing address from on Checkout form page");
        }
    }
}