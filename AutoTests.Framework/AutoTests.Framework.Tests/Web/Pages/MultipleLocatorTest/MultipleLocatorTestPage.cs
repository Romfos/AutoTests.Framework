using AutoTests.Framework.Tests.Web.Elements;

namespace AutoTests.Framework.Tests.Web.Pages.MultipleLocatorTest
{
    public class MultipleLocatorTestPage : DemoPage
    {
        public MultipleLocatorElement Element { get; set; }

        public string StringProperty { get; set; }

        public MultipleLocatorTestPage(Application application) : base(application)
        {
        }
    }
}