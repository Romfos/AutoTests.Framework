using AutoTests.Framework.Components.Application;
using AutoTests.Framework.Playwright.Components;

namespace Boostrap.Tests.Application.Pages;

internal sealed class Checkout
{
    [Route("continue to checkout")]
    public TrivialButton? ContinueToCheckout { get; set; }

    [Route("first name")]
    public TrivialInput? FirstName { get; set; }

    [Route("last name")]
    public TrivialInput? LastName { get; set; }
}
