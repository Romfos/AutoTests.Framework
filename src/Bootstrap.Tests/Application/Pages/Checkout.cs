using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Playwright.Components;

namespace Bootstrap.Tests.Application.Pages;

internal sealed class Checkout
{
    [Route("continue to checkout")]
    [Selector(".btn-primary")]
    public required TrivialButton ContinueToCheckout { get; init; }

    [Route("first name")]
    [Selector("#firstName")]
    public required TrivialInput FirstName { get; init; }

    [Route("last name")]
    [Selector("#lastName")]
    public required TrivialInput LastName { get; init; }

    [Route("username error message")]
    [Selector("#username ~ .invalid-feedback")]
    public required TrivialLabel UsernameErrorMessage { get; init; }
}
