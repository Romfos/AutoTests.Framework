using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Input : ISetValue, IGetValue
{
    public string? value;
    public bool getted = false;

    public Task<object?> GetValueAsync()
    {
        getted = true;
        return Task.FromResult<object?>(value);
    }

    public async Task SetValueAsync(IExpression expression)
    {
        value = await expression.ExecuteAsync<string>();
    }
}
