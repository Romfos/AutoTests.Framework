using AutoTests.Framework.Components.Contracts;
using System.Threading.Tasks;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Button : IClick, IVisible
{
    public bool Clicked = false;

    public Task ClickAsync()
    {
        Clicked = true;
        return Task.CompletedTask;
    }

    public Task<bool> IsVisibleAsync()
    {
        return Task.FromResult(false);
    }
}
