using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Tests.Web.Controls
{
    public class Input : DemoControl, ISetValue<string>, IGetValue<string>
    {
        public string Locator { get; private set; }

        public Input(DemoContext context) : base(context)
        {
        }

        public void SetValue(string value)
        {
            Context.SetValue(Locator, value);
        }

        public string GetValue()
        {
            return Locator;
        }
    }
}