using AutoTests.Framework.Web.Attributes;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class MultipleLocatorElement : DemoElement
    {
        [FromLocator]
        public string Name { get; set; }

        public string Value { get; set; }

        public MultipleLocatorElement(Application application) : base(application)
        {
        }
    }
}