using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Web.Controls
{
    public class Input : SemanticControl, ISetValue<string>
    {
        private string Locator { get; set; }

        public Input(Application application) : base(application)
        {
        }

        public void SetValue(string value)
        {
            Context.SetValue(Locator, value);
        }
    }
}