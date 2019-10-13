using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.Tests.Web.Components.NestedComponentsTest;
using AutoTests.Framework.Tests.Web.Components.StaticResourcesTest;
using AutoTests.Framework.Tests.Web.Components.ConentAttributeTest;
using AutoTests.Framework.Components.Routes;
using AutoTests.Framework.Tests.Web.Components.RoutesTest;
using AutoTests.Framework.Tests.Web.Components.PrivateMemberTest;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class WebFrameworkTests : UnitTestsBase
    {
        [TestMethod]
        public void NestedComponentsTest()
        {
            var container = CreateEmptyContainer();

            var component = container.Resolve<NestedComponentsTestTopComponent>();

            Assert.IsNotNull(component.NestedCompnent);
        }

        [TestMethod]
        public void StaticResourcesTest()
        {
            var container = CreateEmptyContainer();

            var component = container.Resolve<StaticResourcesTestTopComponent>();

            Assert.AreEqual("2", component.Value);
            Assert.AreEqual("3", component.NestedComponent.ValueFromTopResource);
            Assert.AreEqual(1, component.NestedComponent.Value);
            Assert.AreEqual("4", component.PrimaryValueComponent.PrimaryValue);
        }

        [TestMethod]
        public void ConentAttributeTest()
        {
            var container = CreateEmptyContainer();

            var component = container.Resolve<ConentAttributeTestTopComponent>();

            Assert.AreEqual("1", component.NestedCompnent.Value);
        }

        [TestMethod]
        public void RoutesTest()
        {
            var container = CreateEmptyContainer();
            var componentRouter = container.Resolve<ComponentRouter>();

            var component = componentRouter.Resolve("RoutesTestNestedComponent > NestedComponent");

            Assert.IsNotNull(component);
            Assert.IsInstanceOfType(component, typeof(RoutesTestNestedComponent));
        }

        [TestMethod]
        public void PrivateMemberTest()
        {
            var container = CreateEmptyContainer();
            var component = container.Resolve<PrivateMemberTestTopComponent>();

            Assert.AreEqual("abcd", component.GetFirstNestedComponent().GetPrivatePropertyValue());
            Assert.AreEqual("123", component.GetSecondNestedComponent().GetPrivatePropertyValue());
        }
    }
}