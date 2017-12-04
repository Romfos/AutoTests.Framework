using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class Button : DemoElement
    {
        public string Locator { get; private set; }

        public Button(DemoContext context) : base(context)
        {
        }

        [Click]
        public void Click()
        {
            Context.Click(Locator);
        }
    }
}