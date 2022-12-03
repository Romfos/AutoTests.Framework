using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components;

[Binding]
public sealed class ComponentsSteps
{
    private readonly ComponentService componentService;

    public ComponentsSteps(ComponentService componentService)
    {
        this.componentService = componentService;
    }

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

    [When(@"set following values to fields:")]
    public async Task WhenSetFollowingValuesToFields(Dictionary<ArgumentExpression, ArgumentExpression> values)
    {
        foreach (var keyValuePair in values)
        {
            var path = await keyValuePair.Key.ExecuteAsync<string>();
            var value = keyValuePair.Value;
            await componentService.GetComponent<ISetValue>(path).SetValueAsync(value);
        }
    }

    [Then(@"fields should have following values:")]
    public async Task ThenFieldsShouldHaveFollowingValues(Dictionary<ArgumentExpression, ArgumentExpression> values)
    {
        foreach (var keyValuePair in values)
        {
            var path = await keyValuePair.Key.ExecuteAsync<string>();
            var expected = await keyValuePair.Value.ExecuteAsync<object?>();
            var actual = await componentService.GetComponent<IGetValue>(path).GetValueAsync();

            if ((expected == null && actual != null) || !expected!.Equals(actual))
            {
                throw new Exception($"Unexpected value in component. Actual {actual}. Expected: {expected}");
            }
        }
    }
}
