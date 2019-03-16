using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PageObjects.Provider.Attributes;

namespace AutoTests.Framework.Tests.Web.PageObjectProviderTest
{
    [PageObjectName("Test page1")]
    public class PageObjectProviderTestPage : Page
    {
        [PageObjectName("Element1")]
        public PageObjectProviderTestElement1 Element1 { get; set; }

        public PageObjectProviderTestPage(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}