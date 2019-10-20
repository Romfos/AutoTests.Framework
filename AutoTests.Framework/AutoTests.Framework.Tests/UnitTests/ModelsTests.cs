using AutoTests.Framework.Models;
using AutoTests.Framework.Tests.Models.DisabledAttributeTest;
using AutoTests.Framework.Tests.Models.EnabledDisableAttributeTest;
using AutoTests.Framework.Tests.Models.NameAttributeTest;
using AutoTests.Framework.Tests.Models.NestedModelsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class ModelsTests : UnitTestsBase
    {
        [TestMethod]
        public void NestedModelsTest()
        {
            var model = new NestedModelsTestTopModel();
            var property1 = PropertyLink.From(() => model.Value1);
            var property2 = PropertyLink.From(() => model.NestedModel.Value2);

            Assert.AreEqual(1, property1.Value);
            Assert.AreEqual(2, property2.Value);
        }

        [TestMethod]
        public void DisabledAttributeTest()
        {
            var model = new DisabledAttributeTestModel();
            var property = PropertyLink.From(() => model.Value);

            Assert.IsFalse(property.Enabled);
        }

        [TestMethod]
        public void EnabledDisableAttributeTest()
        {
            var model = new EnabledDisableAttributeTestModel();
            var property = PropertyLink.From(() => model.Value);

            property.Enabled = true;
            Assert.IsTrue(property.Enabled);

            property.Enabled = true;
            Assert.IsTrue(property.Enabled);

            property.Enabled = false;
            Assert.IsFalse(property.Enabled);

            property.Enabled = false;
            Assert.IsFalse(property.Enabled);
        }

        [TestMethod]
        public void NameAttributeTest()
        {
            var model = new NameAttributeTestModel();
            var property1 = PropertyLink.From(() => model.Data);
            var property2 = PropertyLink.From(() => model.Value2);

            Assert.AreEqual("value", property1.Name);
            Assert.AreEqual("Value2", property2.Name);
        }
    }
}
