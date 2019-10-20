using AutoTests.Framework.Models;
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
    }
}
