using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Button : CommonElement
    {
        private string Locator { get; set; }

        public Button(WebDependencies dependencies) : base(dependencies)
        {
        }

        [Click]
        public void Click()
        {
            Context.Click(Locator);
        }

        [Displayed]
        public bool IsDisplayed()
        {
            return Context.IsDisplayed(Locator);
        }

        [Enabled]
        public bool IsEnabled()
        {
            return Context.IsEnabled(Locator);
        }

        [Selected]
        public bool IsSelected()
        {
            return Context.IsSelected(Locator);
        }
    }
}