using AutoTests.Framework.Components.Application;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Application : IApplication
{
    [Route("main page")]
    public MainPage? MainPage { get; set; }
}
