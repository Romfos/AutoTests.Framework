using AutoTests.Framework.Models.Extensions;
using AutoTests.Framework.Tests.Web.Pages.Login;
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
                Username = "UsernameInput locator",
                Password = "PasswordInput locator"
            };
            var actual = page.GetLoginModel(expected);

            Assert.AreModelEqual(expected, actual, "GetValue binding not work");
        }
    }
}