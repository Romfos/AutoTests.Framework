using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PageObjects.Attributes;

namespace AutoTests.Framework.Tests.Web.LocatorsLoaderTest.LocatorsLoaderTestElement1
{
    public class LocatorsLoaderTestElement1 : Element
    {
        public string Value1 { get; set; }

        [PrimaryLocator]
        public string Value2 { get; set; }

        public LocatorsLoaderTestElement2.LocatorsLoaderTestElement2 Element1 { get; set; }

        [Locator("LocatorAttribute_Value")]
        public LocatorsLoaderTestElement2.LocatorsLoaderTestElement2 Element2 { get; set; }

        public LocatorsLoaderTestElement1(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}