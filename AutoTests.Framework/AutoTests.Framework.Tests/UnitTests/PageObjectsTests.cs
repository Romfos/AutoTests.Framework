using AutoTests.Framework.Tests.Web.LocatorsLoaderTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class PageObjectsTests : UnitTestsBase
    {
        [TestMethod]
        public void PageObjectLoaderTest()
        {
            var locatorsLoaderTestPage = application.PageObjects.GetPage<LocatorsLoaderTestPage>();

            Assert.AreEqual("LocatorsLoaderTestPage_Locators_Value1", 
                locatorsLoaderTestPage.Value1);

            Assert.AreEqual("LocatorsLoaderTestElement1_Locators_Value1",
                locatorsLoaderTestPage.LocatorsLoaderTestElement1.Value1);

            Assert.AreEqual("LocatorsLoaderTestPage_Locators_Value2", 
                locatorsLoaderTestPage.LocatorsLoaderTestElement1.Value2);

            Assert.AreEqual("LocatorsLoaderTestElement1_Locators_Element2_Value",
                locatorsLoaderTestPage.LocatorsLoaderTestElement1.Element2.Value);
        }
    }
}