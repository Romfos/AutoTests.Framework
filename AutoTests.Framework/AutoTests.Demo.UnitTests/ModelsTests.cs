using System.Linq;
using AutoTests.Demo.Common.Models;
using AutoTests.Framework.Core.Tests;
using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Comparator;
using AutoTests.Framework.Models.PropertyAttributes;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = AutoTests.Framework.Core.Tests.Assert;

namespace AutoTests.Demo.UnitTests
{
    [TestClass]
    public class ModelsTests
    {
        private Assert Assert { get; } = new Assert(new TestsDependencies(new ObjectContainer()));

        [TestMethod]
        public void ModelSetupTest()
        {
            var model = new ParentModel();

            Assert.IsNotNull(model.SubModel, "SubModel cannot be null");

            Assert.AreEqual("Title", PropertyLink.Get(() => model.Name).Name,
                "Incorrect 'Name' attribute work");
            Assert.AreEqual("Enabled", PropertyLink.Get(() => model.Enabled).Name,
                "Incorrect 'Name' attribute work");
            Assert.AreEqual("Value", PropertyLink.Get(() => model.SubModel.Value).Name,
                "Incorrect 'Name' attribute work");

            Assert.AreEqual(true, PropertyLink.Get(() => model.Name).Enabled,
                "Incorrect 'Enabled' attribute work");
            Assert.AreEqual(false, PropertyLink.Get(() => model.Enabled).Enabled,
                "Incorrect 'Enabled' attribute work");
            Assert.AreEqual(true, PropertyLink.Get(() => model.SubModel.Value).Enabled,
                "Incorrect 'Enabled' attribute work");
        }

        [TestMethod]
        public void DisabledAttributeTest()
        {
            var model = new ParentModel();
            var propertyLink = PropertyLink.Get(() => model.Enabled);

            Assert.AreEqual(false, propertyLink.Enabled, "Incorrect 'Enabled' attribute work");
            Assert.AreEqual(1, propertyLink.Attributes.OfType<DisabledAttribute>().Count(),
                "Incorrect 'Enabled' attribute work");

            propertyLink.Enabled = true;

            Assert.AreEqual(true, propertyLink.Enabled, "Incorrect 'Enabled' attribute work");
            Assert.AreEqual(0, propertyLink.Attributes.OfType<DisabledAttribute>().Count(),
                "Incorrect 'Enabled' attribute work");

            propertyLink.Enabled = false;

            Assert.AreEqual(false, propertyLink.Enabled, "Incorrect 'Enabled' attribute work");
            Assert.AreEqual(1, propertyLink.Attributes.OfType<DisabledAttribute>().Count(),
                "Incorrect 'Enabled' attribute work");
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
                SubModel = {Value = 2}
            };

            var results = comparator.Compare(expected, actual).ToArray();

            Assert.AreEqual(2, results.Length, "Incorrect comparator work");
            Assert.AreEqual("Property 'Title' contain incorrect value. Expected: 'name1'. Actual: 'name2'",
                results[0].ToString(), "Incorrect comparator work");
            Assert.AreEqual("Property 'Value' contain incorrect value. Expected: '1'. Actual: '2'",
                results[1].ToString(), "Incorrect comparator work");
        }
    }
}