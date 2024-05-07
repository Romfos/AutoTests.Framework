using AutoTests.Framework.Components.Attributes;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class MainPage
{
    [Route("login")]
    public required Button Login { get; set; }

    [Route("first name")]
    public required Input FirstName { get; set; }

    [Route("data")]
    public required DataComponent DataComponent { get; set; }

    [Route("locator")]
    [Selector("12345")]
    public required LocatorComponent Locator { get; set; }
}
