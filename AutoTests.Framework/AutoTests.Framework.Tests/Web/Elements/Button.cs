using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class Button : DemoElement
    {
        [FromLocator]
        public string Locator { get; private set; }

        public Button(Application application) : base(application)
        {
        }

        [Click]
        public void Click()
        {
            Context.Click(Locator);
        }
    }
}