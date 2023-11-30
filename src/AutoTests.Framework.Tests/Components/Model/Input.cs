using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Input : ISetValue, IGetValue, IVisible, IEnabled
{
    public string? setValueContent;
    public bool isGetMethodCalled = false;

    public Task<object?> GetValueAsync()
    {
        isGetMethodCalled = true;
        return Task.FromResult<object?>(setValueContent);
    }

    public Task<bool> IsEnabledAsync()
    {
        return Task.FromResult(true);
    }

    public Task<bool> IsVisibleAsync()
    {
        return Task.FromResult(true);
    }

    public async Task SetValueAsync(ArgumentExpression expression)
    {
        setValueContent = await expression.ExecuteAsync<string>();
    }
}
