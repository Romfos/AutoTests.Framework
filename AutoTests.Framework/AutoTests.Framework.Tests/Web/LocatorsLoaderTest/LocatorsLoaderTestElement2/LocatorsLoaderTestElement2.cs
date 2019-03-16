using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PageObjects.Attributes;

namespace AutoTests.Framework.Tests.Web.LocatorsLoaderTest.LocatorsLoaderTestElement2
{
    public class LocatorsLoaderTestElement2 : Element
    {
        [PrimaryLocator]
        public string Value { get; set; }

        public LocatorsLoaderTestElement2(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}