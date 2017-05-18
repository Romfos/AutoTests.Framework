namespace AutoTests.Demo.Common.Web.Controls
{
    public class Input : DemoControl
    {
        public string Locator { get; private set; }

        public Input(DemoContext context) : base(context)
        {
        }
    }
}