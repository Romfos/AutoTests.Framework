using AutoTests.Framework.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class PageObjectsTests : UnitTestsBase
    {
        [TestMethod]
        public void PageObjectElementsLoaderTest()
        {
            var testPage = application.PageObjects.GetPage<TestPage>();

            Assert.IsNotNull(testPage);
        }

        public class TestPage : Page
        {
            public TestElement TestElement { get; set; }

            public TestPage(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
            {
            }
        }

        public class TestElement : Element
        {
            public TestElement(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
            {
            }
        }
    }
}