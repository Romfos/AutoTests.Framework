using AutoTests.Framework.Components.Application;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class MainPage
{
    [Route("login")]
    public Button? Button { get; set; }
}
