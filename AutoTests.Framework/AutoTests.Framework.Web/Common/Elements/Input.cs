using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Input : CommonElement
    {
        [FromLocator]
        private string Locator { get; set; }

        public Input(WebDependencies dependencies) : base(dependencies)
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

        [Selected]
        public bool IsSelected()
        {
            return Context.IsSelected(Locator);
        }

        [GetValue]
        public string GetValue()
        {
            return CommonScriptLibrary.GetValue(Locator);
        }

        [SetValue]
        public void SetValue(string value)
        {
            Context.Clear(Locator);
            Context.SetValue(Locator, value);
        }
    }
}