namespace AutoTests.Demo.Common.Web.Controls
{
    public class Button : DemoControl
    {
        public string Locator { get; private set; }

        public Button(DemoContext context) : base(context)
        {
        }
    }
}