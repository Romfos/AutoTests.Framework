using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PageObjects.Provider.Attributes;

namespace AutoTests.Framework.Tests.Web.ContractsTest
{
    [PageObjectName("contract page 1")]
    public class ContractsPage1 : Page
    {
        [PageObjectName("element 1")]
        public ContractsElement1 Element1 { get; set; }

        public ContractsPage1(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}