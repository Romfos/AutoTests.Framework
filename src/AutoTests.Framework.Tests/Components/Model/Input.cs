using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Input : ISetValue, IGetValue, IVisible, IEnabled
{
    public string? value;
    public bool getted = false;

    public Task<object?> GetValueAsync()
    {
        getted = true;
        return Task.FromResult<object?>(value);
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
        value = await expression.ExecuteAsync<string>();
    }
}
