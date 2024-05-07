using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Components.Attributes;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class Application : IApplication
{
    [Route("main page")]
    public required MainPage MainPage { get; init; }
}
