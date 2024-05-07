using AutoTests.Framework.Components.Attributes;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class MainPage
{
    [Route("login")]
    public required Button Login { get; init; }

    [Route("first name")]
    public required Input FirstName { get; init; }

    [Route("data")]
    public required DataComponent DataComponent { get; init; }

    [Route("locator")]
    [Selector("12345")]
    public required LocatorComponent Locator { get; init; }
}
