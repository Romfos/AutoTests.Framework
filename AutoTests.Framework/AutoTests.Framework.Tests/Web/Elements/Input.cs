using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class Input : DemoElement
    {
        public string Locator { get; private set; }

        public Input(DemoContext context) : base(context)
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