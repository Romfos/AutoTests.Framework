using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Tests.Web.Components.NestedComponentsTest;
using AutoTests.Framework.Tests.Web.Components.StaticResourcesTest;
using AutoTests.Framework.Tests.Web.Components.ConentAttributeTest;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class WebFrameworkTests : UnitTestsBase
    {
        [TestMethod]
        public void NestedComponentsTest()
        {
            var container = CreateEmptyContainer();

            var nestedComponentsTestTopComponent = container.Resolve<NestedComponentsTestTopComponent>();

            Assert.IsNotNull(nestedComponentsTestTopComponent.NestedCompnent);
        }

        [TestMethod]
        public void StaticResourcesTest()
        {
            var container = CreateEmptyContainer();

            var nestedComponentsTestTopComponent = container.Resolve<StaticResourcesTestTopComponent>();

            Assert.AreEqual("2", nestedComponentsTestTopComponent.Value);
            Assert.AreEqual("3", nestedComponentsTestTopComponent.NestedComponent.ValueFromTopResource);
            Assert.AreEqual(1, nestedComponentsTestTopComponent.NestedComponent.Value);
            Assert.AreEqual("4", nestedComponentsTestTopComponent.PrimaryValueComponent.PrimaryValue);
        }

        [TestMethod]
        public void ConentAttributeTest()
        {
            var container = CreateEmptyContainer();

            var conentAttributeTestTopComponent = container.Resolve<ConentAttributeTestTopComponent>();

            Assert.AreEqual("1", conentAttributeTestTopComponent.NestedCompnent.Value);
        }
    }
}