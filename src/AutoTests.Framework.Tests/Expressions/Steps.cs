using AutoTests.Framework.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Expressions;

[Binding]
public sealed class Steps
{
    [Then(@"expression test step 1 '([^']*)'")]
    public async Task ThenExpressionTestStep1(ArgumentExpression expression)
    {
        Assert.AreEqual(3, await expression.ExecuteAsync<int>());
    }

    [Then(@"expression test step 2 '([^']*)'")]
    public async Task ThenExpressionTestStep2(ArgumentExpression expression)
    {
        Assert.AreEqual("1+2", await expression.ExecuteAsync<string>());
    }

    [Then(@"expression test step 3 '([^']*)'")]
    public async Task ThenExpressionTestStep3(ArgumentExpression expression)
    {
        Assert.AreEqual("Value", await expression.ExecuteAsync<string>());
    }
}
