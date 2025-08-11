using AutoTests.Framework.Pages;

namespace Bootstrap.Tests.Pages;

internal sealed class BootstrapApplication
{
    [Route("checkout")]
    public required Checkout Checkout { get; init; }
}
