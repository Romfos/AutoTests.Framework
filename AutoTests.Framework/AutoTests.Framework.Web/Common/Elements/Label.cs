using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Label : CommonElement, IGetValue<string>, IDisplayed, ISelected, IEnabled
    {
        private string Locator { get; set; }

        public Label(WebDependencies dependencies) : base(dependencies)
        {
        }

        public bool Displayed => Context.IsDisplayed(Locator);

        public bool Enabled => Context.IsEnabled(Locator);

        public string GetValue()
        {
            return Context.GetText(Locator);
        }

        public bool Selected => Context.IsSelected(Locator);
    }
}