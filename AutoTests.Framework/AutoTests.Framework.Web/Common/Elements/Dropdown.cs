using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Web.Common.Elements
{
    public class Dropdown : CommonElement, ISetValue<string>, IGetValue<string>, IDisplayed, ISelected, IEnabled
    {
        private string Locator { get; set; }

        public Dropdown(WebDependencies dependencies) : base(dependencies)
        {
        }

        public bool Displayed => Context.IsDisplayed(Locator);

        public bool Enabled => Context.IsEnabled(Locator);

        public string GetValue()
        {
            return Context.ScriptLibrary.GetValue(Locator);
        }

        public bool Selected => Context.IsSelected(Locator);

        public void SetValue(string value)
        {
            Context.ScriptLibrary.SetValue(Locator, value);
        }
    }
}