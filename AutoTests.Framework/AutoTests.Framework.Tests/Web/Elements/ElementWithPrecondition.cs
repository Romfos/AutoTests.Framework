using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class ElementWithPrecondition : DemoElement
    {
        [FromLocator]
        public string LocatorTemplate { get; set; }

        public int Position { get; set; }

        public ElementWithPrecondition(Application application) : base(application)
        {
        }

        [GetValue]
        public string GetValue()
        {
            return string.Format(LocatorTemplate, Position);
        }
    }
}