using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Button : CommonElement, IClick, IDisplayed, ISelected, IEnabled
    {
        private string Locator { get; set; }

        public Button(WebDependencies dependencies) : base(dependencies)
        {
        }

        public void Click()
        {
            Context.Click(Locator);
        }

        public bool Displayed => Context.IsDisplayed(Locator);

        public bool Enabled => Context.IsEnabled(Locator);

        public bool Selected => Context.IsSelected(Locator);
    }
}