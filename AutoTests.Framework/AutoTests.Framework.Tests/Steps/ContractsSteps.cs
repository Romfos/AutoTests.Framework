using AutoTests.Framework.Tests.Web.ContractsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Steps
{
    [Binding]
    public class ContractsSteps : StepsBase
    {
        public ContractsSteps(Application application) : base(application)
        {
        }

        [Then(@"value for contract element 1 should be '(.*)'")]
        public void ValueForContractElementShouldBe(string value)
        {
            var contractsPage1 = application.PageObjects.GetPage<ContractsPage1>();

            Assert.AreEqual(value, contractsPage1.Element1.Value);
        }
    }
}