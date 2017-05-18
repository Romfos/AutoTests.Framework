using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Demo.Common.Web.Controls
{
    public class Input : DemoControl, ISetValue<string>
    {
        public string Locator { get; private set; }

        public Input(DemoContext context) : base(context)
        {
        }

        public void SetValue(string value)
        {
            Context.SetValue(Locator, value);
        }
    }
}