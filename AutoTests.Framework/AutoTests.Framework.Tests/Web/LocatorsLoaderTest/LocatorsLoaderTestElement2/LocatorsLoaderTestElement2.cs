using AutoTests.Framework.PageObjects;

namespace AutoTests.Framework.Tests.Web.LocatorsLoaderTest.LocatorsLoaderTestElement2
{
    public class LocatorsLoaderTestElement2 : Element
    {
        public string Value { get; set; }

        public LocatorsLoaderTestElement2(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}