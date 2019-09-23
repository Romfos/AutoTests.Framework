using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Tests.Web.Components;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class WebFrameworkTests : UnitTestsBase
    {
        [TestMethod]
        public void NestedComponentsTest()
        {
            var container = CreateEmptyContainer();

            var nestedComponentsTestComponent = container.Resolve<NestedComponentsTestComponent>();

            Assert.IsNotNull(nestedComponentsTestComponent.NestedCompnent);
        }
    }
}