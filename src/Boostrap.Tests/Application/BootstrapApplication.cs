using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Attributes;
using Boostrap.Tests.Application.Pages;

namespace Boostrap.Tests.Application;

internal sealed class BootstrapApplication : IApplication
{
    [Route("checkout")]
    public Checkout? Checkout { get; set; }
}
