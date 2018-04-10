using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class Input : DemoElement
    {
        [FromLocator]
        public string Locator { get; private set; }

        public Input(Application application) : base(application)
        {
        }

        [SetValue]
        public void SetValue(string value)
        {
            Context.SetValue(Locator, value);
        }

        [GetValue]
        public string GetValue()
        {
            return Locator;
        }
    }
}