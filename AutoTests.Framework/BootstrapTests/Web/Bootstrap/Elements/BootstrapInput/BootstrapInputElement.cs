using AutoTests.Framework.PageObjects.Attributes;
using AutoTests.Framework.PageObjects.Contracts.PageObjectContracts;

namespace BootstrapTests.Web.Bootstrap.Elements.BootstrapInput
{
    public class BootstrapInputElement : BootstrapElement, ISetValueContract<string>, IGetValueContract<string>
    {
        [PrimaryLocator]
        private string Locator { get; set; }

        public BootstrapInputElement(Application application) : base(application)
        {
        }

        public void SetValue(string value)
        {
            Context.SetValue(Locator, value);
        }

        public string GetValue()
        {
            return Context.GetValue(Locator);
        }
    }
}
