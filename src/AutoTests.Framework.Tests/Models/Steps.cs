using AutoTests.Framework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace AutoTests.Framework.Tests.Models;

[Binding]
public sealed class Steps
{
    [Then(@"model test step 1:")]
    public async Task ThenModelTestStep1(IModel model)
    {
        var actual = await model.GetValueAsync<TestModel1>();

        Assert.IsTrue(actual is { X: 3, Y: "Hello World!" });
    }

    [Then(@"model test step 2:")]
    public async Task ThenModelTestStep2(IModel model)
    {
        var actual = await model.GetValuesAsync<TestModel1>().ToListAsync();

        Assert.IsTrue(actual is [{ X: 3, Y: "Hello World!" }, { X: 3, Y: "xy" }]);
    }
}
