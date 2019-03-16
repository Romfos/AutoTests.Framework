using AutoTests.Framework.PageObjects;

namespace AutoTests.Framework.Tests.Web.LocatorsLoaderTest
{
    public class LocatorsLoaderTestPage : Page
    {
        public string Value1 { get; set; }

        public LocatorsLoaderTestElement1.LocatorsLoaderTestElement1 LocatorsLoaderTestElement1 { get; set; }

        public LocatorsLoaderTestPage(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}