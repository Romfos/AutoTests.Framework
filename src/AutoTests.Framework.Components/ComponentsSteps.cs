using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components;

[Binding]
public sealed class ComponentsSteps
{
    [When(@"click on '([^']*)'")]
    public async Task WhenClickOn(IComponentReference componentReference)
    {
        await componentReference.GetComponent<IClick>().ClickAsync();
    }

    [When(@"set value '([^']*)' in '([^']*)' field")]
    public async Task WhenSetValueIn(ArgumentExpression expression, IComponentReference componentReference)
    {
        await componentReference.GetComponent<ISetValue>().SetValueAsync(expression);
    }

    [Then(@"field '([^']*)' should have '([^']*)' value")]
    public async Task WhenValueShouldHave(IComponentReference componentReference, ArgumentExpression expression)
    {
        var expected = await expression.ExecuteAsync<object?>();
        var actual = await componentReference.GetComponent<IGetValue>().GetValueAsync();

        if ((expected == null && actual != null) || !expected!.Equals(actual))
        {
            throw new Exception($"Unexpected value in component. Actual {actual}. Expected: {expected}");
        }
    }
}
