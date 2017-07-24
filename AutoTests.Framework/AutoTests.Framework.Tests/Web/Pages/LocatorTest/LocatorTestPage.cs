using AutoTests.Framework.Tests.Web.Elements;
using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Attributes;

namespace AutoTests.Framework.Tests.Web.Pages.LocatorTest
{
    public class LocatorTestPage : Page
    {
        [Locator("Test locator")]
        public Input Input { get; set; }

        public LocatorTestPage(WebDependencies dependencies) : base(dependencies)
        {
        }
    }
}