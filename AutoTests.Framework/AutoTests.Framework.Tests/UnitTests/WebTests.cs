using AutoTests.Framework.Models.Extensions;
using AutoTests.Framework.Tests.Web.Pages.LocatorTest;
using AutoTests.Framework.Tests.Web.Pages.Login;
using AutoTests.Framework.Tests.Web.Pages.MultipleLocatorTest;
using AutoTests.Framework.Tests.Web.Pages.PreconditionTest;
using AutoTests.Framework.Web.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class WebTests : UnitTestBase
    {
        [TestMethod]
        public void GetValueBindingTest()
        {
            var page = Application.Web.GetPage<LoginPage>();
            var expected = new LoginModel
            {
                Username = "#Username",
                Password = "#Password"
            };
            var actual = page.BindLoginModel().GetValues();

            Assert.AreModelEqual(expected, actual, "GetValue binding not work");
        }

        [TestMethod]
        public void LocatorAttributeTest()
        {
            var page = Application.Web.GetPage<LocatorTestPage>();

            Assert.AreEqual("Test locator", page.Input.Locator, "LocatorAttribute not work");
        }

        [TestMethod]
        public void MultipleLocatorTest()
        {
            var page = Application.Web.GetPage<MultipleLocatorTestPage>();

            Assert.AreEqual("abcd", page.Element.Name, "Incorrect locator");
            Assert.AreEqual("123", page.Element.Value, "Incorrect locator");
            Assert.AreEqual("ABCD", page.StringProperty, "Incorrect value");
        }

        [TestMethod]
        public void PreconditionTest()
        {
            var page = Application.Web.GetPage<PreconditionTestPage>();
            var expected = new PreconditionTestModel
            {
                Value = "ABC_1"
            };
            var actual = page.BindPreconditionTestModel(1).GetValues();

            Assert.AreModelEqual(expected, actual, "Incorrect values");
        }
    }
}