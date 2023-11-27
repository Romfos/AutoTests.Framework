using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Playwright.Components;

namespace Bootstrap.Tests.Application.Pages;

internal sealed class Checkout
{
    [Route("continue to checkout")]
    [Selector(".btn-primary")]
    public TrivialButton? ContinueToCheckout { get; set; }

    [Route("first name")]
    [Selector("#firstName")]
    public TrivialInput? FirstName { get; set; }

    [Route("last name")]
    [Selector("#lastName")]
    public TrivialInput? LastName { get; set; }

    [Route("username error message")]
    [Selector("#username ~ .invalid-feedback")]
    public TrivialLabel? UsernameErrorMessage { get; set; }
}
