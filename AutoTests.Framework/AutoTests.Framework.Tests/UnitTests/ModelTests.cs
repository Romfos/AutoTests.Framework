using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Framework.Tests.UnitTests
{
    [TestClass]
    public class ModelTests : UnitTestsBase
    {
        [TestMethod]
        public void ModelInitializerTest()
        {
            var model1 = new Model1();

            Assert.IsNotNull(model1.Model2);
        }

        [TestMethod]
        public void PropertyLinkTest()
        {
            var model1 = new Model1();
            var propertyLink = PropertyLink.Get(() => model1.Model2.Value);
            propertyLink.Value = 123;

            Assert.AreEqual(123, model1.Model2.Value);
            Assert.AreEqual(123, propertyLink.Value);
        }

        public class Model1 : Model
        {
            public string Name { get; set; }

            public Model2 Model2 { get; private set; }
        }

        public class Model2 : Model
        {
            [Name("Value1")]
            public int Value { get; set; }
        }
    }
}