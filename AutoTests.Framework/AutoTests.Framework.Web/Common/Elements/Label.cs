using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Label : CommonElement
    {
        private string Locator { get; set; }

        public Label(WebDependencies dependencies) : base(dependencies)
        {
        }

        [Selected]
        public bool IsSelected()
        {
            return Context.IsSelected(Locator);
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

        [GetValue]
        public string GetValue()
        {
            return Context.GetText(Locator);
        }
    }
}