using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public class Input : DemoElement, ISetValue<string>, IGetValue<string>
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