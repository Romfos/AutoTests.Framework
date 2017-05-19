using System.Linq;
using AutoTests.Demo.Common.Models;
using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Comparator;
using AutoTests.Framework.Models.PropertyAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTests.Demo.UnitTests
{
    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void ModelSetupTest()
        {
            var model = new ParentModel();

            Assert.IsNotNull(model.SubModel);

            Assert.AreEqual("Title", PropertyLink.Get(() => model.Name).Name);
            Assert.AreEqual("Enabled", PropertyLink.Get(() => model.Enabled).Name);
            Assert.AreEqual("Value", PropertyLink.Get(() => model.SubModel.Value).Name);

            Assert.AreEqual(true, PropertyLink.Get(() => model.Name).Enabled);
            Assert.AreEqual(false, PropertyLink.Get(() => model.Enabled).Enabled);
            Assert.AreEqual(true, PropertyLink.Get(() => model.SubModel.Value).Enabled);
        }

        [TestMethod]
        public void DisabledAttributeTest()
        {
            var model = new ParentModel();
            var propertyLink = PropertyLink.Get(() => model.Enabled);

            Assert.AreEqual(false, propertyLink.Enabled);
            Assert.AreEqual(1, propertyLink.Attributes.OfType<DisabledAttribute>().Count());
            
            propertyLink.Enabled = true;

            Assert.AreEqual(true, propertyLink.Enabled);
            Assert.AreEqual(0, propertyLink.Attributes.OfType<DisabledAttribute>().Count());

            propertyLink.Enabled = false;

            Assert.AreEqual(false, propertyLink.Enabled);
            Assert.AreEqual(1, propertyLink.Attributes.OfType<DisabledAttribute>().Count());
        }

        [TestMethod]
        public void ModelComparatorTests()
        {
            var comparator = new ModelComparator();

            var expected = new ParentModel
            {
                Name = "name1",
                Enabled = true,
                SubModel = {Value = 1}
            };

            var actual = new ParentModel
            {
                Name = "name2",
                Enabled = false,
                SubModel = { Value = 2 }
            };

            var results = comparator.Compare(expected, actual).ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual("Property 'Title' contain incorrect value. Expected: 'name1'. Actual: 'name2'", results[0].ToString());
            Assert.AreEqual("Property 'Value' contain incorrect value. Expected: '1'. Actual: '2'", results[1].ToString());
        }
    }
}