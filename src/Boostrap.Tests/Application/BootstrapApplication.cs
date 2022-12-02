using AutoTests.Framework.Components.Application;
using Boostrap.Tests.Application.Pages;

namespace Boostrap.Tests.Application;

internal sealed class BootstrapApplication : IApplication
{
    [Route("checkout")]
    public Checkout? Checkout { get; set; }
}
