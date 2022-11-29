using AutoTests.Framework.Models;
using AutoTests.Framework.Tests.Models.DisabledAttributeTest;
using AutoTests.Framework.Tests.Models.EnabledDisableAttributeTest;
using AutoTests.Framework.Tests.Models.ModelComparatorTest;
using AutoTests.Framework.Tests.Models.NameAttributeTest;
using AutoTests.Framework.Tests.Models.NestedModelsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AutoTests.Framework.Tests.UnitTests;

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

    [TestMethod]
    public void ComparatorPositiveTest()
    {
        var modelComparator = new ModelComparator();

        var expected = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "2"
        };
        var actual = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "3"
        };
        PropertyLink.From(() => expected.Value2).Enabled = false;

        Assert.IsTrue(modelComparator.Compare(expected, actual));
    }

    [TestMethod]
    public void ComparatorNegativeTest()
    {
        var modelComparator = new ModelComparator();

        var expected = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "2"
        };
        var actual = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "3"
        };
        PropertyLink.From(() => expected.Value1).Enabled = false;

        Assert.IsFalse(modelComparator.Compare(expected, actual));
    }

    [TestMethod]
    public void ComparatorModelArrayPositiveTest()
    {
        var modelComparator = new ModelComparator();

        var expected = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "2"
        };
        var actual = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "3"
        };
        PropertyLink.From(() => expected.Value2).Enabled = false;

        Assert.IsTrue(modelComparator.Compare(new[] { expected }, new[] { actual }));
    }

    [TestMethod]
    public void ComparatorModelArrayNegativeTest()
    {
        var modelComparator = new ModelComparator();

        var expected = new ModelComparatorTestModel()
        {
            Value1 = 1,
            Value2 = "2"
        };
        var actual = new ModelComparatorTestModel()
        {
            Value1 = 2,
            Value2 = "3"
        };
        PropertyLink.From(() => expected.Value2).Enabled = false;

        Assert.IsFalse(modelComparator.Compare(new[] { expected }, new[] { actual }));
    }
}
