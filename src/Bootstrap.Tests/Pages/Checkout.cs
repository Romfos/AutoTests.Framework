using AutoTests.Framework.Pages;
using AutoTests.Framework.Playwright;

namespace Bootstrap.Tests.Pages;

internal sealed class Checkout
{
    [Route("continue to checkout")]
    [Options(".btn-primary")]
    public required Button ContinueToCheckout { get; init; }

    [Route("first name")]
    [Options("#firstName")]
    public required Input FirstName { get; init; }

    [Route("last name")]
    [Options("#lastName")]
    public required Input LastName { get; init; }

    [Route("username error message")]
    [Options("#username ~ .invalid-feedback")]
    public required Label UsernameErrorMessage { get; init; }
}
