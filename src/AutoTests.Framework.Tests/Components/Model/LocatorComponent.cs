using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Contracts;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class LocatorComponent : IGetValue
{
    [FromSelector]
    public string? Selector { get; set; }

    public Task<object?> GetValueAsync()
    {
        return Task.FromResult<object?>(Selector);
    }
}
