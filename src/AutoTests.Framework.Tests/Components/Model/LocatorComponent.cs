using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class LocatorComponent : IGetValue
{
    [FromSelector]
    public required string Selector { get; init; }

    public Task<object?> GetValueAsync()
    {
        return Task.FromResult<object?>(Selector);
    }
}
