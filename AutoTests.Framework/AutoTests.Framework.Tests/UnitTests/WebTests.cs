using AutoTests.Framework.Models.Extensions;
using AutoTests.Framework.Tests.Web.Pages.LocatorTest;
using AutoTests.Framework.Tests.Web.Pages.Login;
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
            var actual = page.BindLoginModel().GetValue();

            Assert.AreModelEqual(expected, actual, "GetValue binding not work");
        }

        [TestMethod]
        public void LocatorAttributeTest()
        {
            var page = Application.Web.GetPage<LocatorTestPage>();

            Assert.AreEqual("Test locator", page.Input.Locator, "LocatorAttribute not work");
        }
    }
}