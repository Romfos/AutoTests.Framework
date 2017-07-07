using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Checkbox : CommonElement, ISetValue<bool>, IGetValue<bool>, IDisplayed, ISelected, IEnabled
    {
        private string Locator { get; set; }

        public Checkbox(WebDependencies dependencies) : base(dependencies)
        {
        }

        public bool Displayed => Context.IsDisplayed(Locator);

        public bool Enabled => Context.IsEnabled(Locator);

        public bool GetValue()
        {
            return Selected;
        }

        public bool Selected => Context.IsSelected(Locator);

        public void SetValue(bool value)
        {
            if (Selected != value)
            {
                Context.Click(Locator);
            }
        }
    }
}