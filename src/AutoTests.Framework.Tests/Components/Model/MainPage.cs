using AutoTests.Framework.Components.Attributes;

namespace AutoTests.Framework.Tests.Components.Model;

internal sealed class MainPage
{
    [Route("login")]
    public Button? Login { get; set; }

    [Route("first name")]
    public Input? FirstName { get; set; }

    [Route("data")]
    public DataComponent? DataComponent { get; set; }

    [Route("locator")]
    [Selector("12345")]
    public LocatorComponent? Locator { get; set; }
}
