using AutoTests.Framework.Components.Contracts;
using AutoTests.Framework.Expressions;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Input : ISetValue
{
    public string? value;

    public async Task SetValueAsync(IExpression expression)
    {
        value = await expression.ExecuteAsync<string>();
    }
}
