using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Attributes;
using Bootstrap.Tests.Application.Pages;

namespace Bootstrap.Tests.Application;

internal sealed class BootstrapApplication : IApplication
{
    [Route("checkout")]
    public required Checkout Checkout { get; set; }
}
