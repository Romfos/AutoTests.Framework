using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Playwright.Components;

namespace Boostrap.Tests.Application.Pages;

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
}
