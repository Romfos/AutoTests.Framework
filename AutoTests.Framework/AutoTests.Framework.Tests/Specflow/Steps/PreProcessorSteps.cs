using AutoTests.Framework.PreProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Tests.Specflow.Steps;

[Binding]
public class PreProcessorSteps
{
    [Then(@"PreProcessor expression '(.*)' should be equal '(.*)'")]
    public async Task ThenPreProcessorExpressionShouldBeEqual(IExpression expression, int expected)
    {
        var actual = await expression.ExecuteAsync<int>();

        Assert.AreEqual(expected, actual);
    }
}
