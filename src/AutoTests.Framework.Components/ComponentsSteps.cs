using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Expressions;
using Reqnroll;

namespace AutoTests.Framework.Components;

[Binding]
public sealed class ComponentsSteps(ComponentService componentService)
{
    [When(@"click on '([^']*)'")]
    public async Task WhenClickOn(ComponentReference componentReference)
    {
        await componentReference.GetComponent<IClick>().ClickAsync();
    }

    [When(@"set following values:")]
    public async Task WhenSetFollowingValuesToFields(Dictionary<ArgumentExpression, ArgumentExpression> values)
    {
        foreach (var keyValuePair in values)
        {
            var path = await keyValuePair.Key.ExecuteAsync<string>();
            var value = keyValuePair.Value;
            await componentService.GetComponent<ISetValue>(path).SetValueAsync(value);
        }
    }

    [Then(@"should have following values:")]
    public async Task ThenFieldsShouldHaveFollowingValues(Dictionary<ArgumentExpression, ArgumentExpression> values)
    {
        var errors = new List<string>();

        foreach (var keyValuePair in values)
        {
            var path = await keyValuePair.Key.ExecuteAsync<string>();
            var expected = await keyValuePair.Value.ExecuteAsync<object?>();
            var actual = await componentService.GetComponent<IGetValue>(path).GetValueAsync();

            if ((expected, actual) is (null, not null) or (not null, null)
                || (expected != null && !expected.Equals(actual)))
            {
                errors.Add($"Path '{path}'. Actual '{actual}'. Expected: '{expected}'");
            }
        }

        if (errors is not [])
        {
            throw new Exception($"Some components have unexpected values: {string.Join(Environment.NewLine, errors)}");
        }
    }

    [Then(@"should be visible:")]
    public async Task ThenShouldBeVisible(IEnumerable<ArgumentExpression> argumentExpressions)
    {
        var errors = new List<string>();

        foreach (var argumentExpression in argumentExpressions)
        {
            var path = await argumentExpression.ExecuteAsync<string>();
            if (!await componentService.GetComponent<IVisible>(path).IsVisibleAsync())
            {
                errors.Add(path);
            }
        }

        if (errors is not [])
        {
            throw new Exception($"Some components are invisible: {string.Join(",", errors)}");
        }
    }

    [Then(@"should be invisible:")]
    public async Task ThenShouldBeInvisible(IEnumerable<ArgumentExpression> argumentExpressions)
    {
        var errors = new List<string>();

        foreach (var argumentExpression in argumentExpressions)
        {
            var path = await argumentExpression.ExecuteAsync<string>();
            if (await componentService.GetComponent<IVisible>(path).IsVisibleAsync())
            {
                errors.Add(path);
            }
        }

        if (errors is not [])
        {
            throw new Exception($"Some components are visible: {string.Join(",", errors)}");
        }
    }

    [Then(@"should be enabled:")]
    public async Task ThenShouldBeEnabled(IEnumerable<ArgumentExpression> argumentExpressions)
    {
        var errors = new List<string>();

        foreach (var argumentExpression in argumentExpressions)
        {
            var path = await argumentExpression.ExecuteAsync<string>();
            if (!await componentService.GetComponent<IEnabled>(path).IsEnabledAsync())
            {
                errors.Add(path);
            }
        }

        if (errors is not [])
        {
            throw new Exception($"Some components are disabled: {string.Join(",", errors)}");
        }
    }

    [Then(@"should be disabled:")]
    public async Task ThenShouldBeDisabled(IEnumerable<ArgumentExpression> argumentExpressions)
    {
        var errors = new List<string>();

        foreach (var argumentExpression in argumentExpressions)
        {
            var path = await argumentExpression.ExecuteAsync<string>();
            if (await componentService.GetComponent<IEnabled>(path).IsEnabledAsync())
            {
                errors.Add(path);
            }
        }

        if (errors is not [])
        {
            throw new Exception($"Some components are enabled: {string.Join(",", errors)}");
        }
    }
}
