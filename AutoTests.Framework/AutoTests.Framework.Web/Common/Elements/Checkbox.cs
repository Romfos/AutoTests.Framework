using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Checkbox : CommonElement
    {
        [FromLocator]
        private string Locator { get; set; }

        public Checkbox(WebDependencies dependencies) : base(dependencies)
        {
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
        public bool GetValue()
        {
            return IsSelected();
        }

        [Selected]
        public bool IsSelected()
        {
            return Context.IsSelected(Locator);
        }

        [SetValue]
        public void SetValue(bool value)
        {
            if (IsSelected() != value)
            {
                Context.Click(Locator);
            }
        }
    }
}