using AutoTests.Framework.Web.Binding.Contracts;

namespace AutoTests.Web.Controls
{
    public class Button : SemanticControl, IClick
    {
        private string Locator { get; set; }

        public Button(Application application) : base(application)
        {
        }

        public void Click()
        {
            Context.Click(Locator);
        }
    }
}