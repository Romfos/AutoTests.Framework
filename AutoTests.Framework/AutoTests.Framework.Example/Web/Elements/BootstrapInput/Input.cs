using AutoTests.Framework.Example.Web.Handlers;
using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Example.Web.Elements.BootstrapInput
{
    public class Input : BootstrapElement
    {
        [FromLocator]
        private string Locator { get; set; }

        private string ValidationMessagePostfixLocator { get; set; }

        public Input(Application application) : base(application)
        {
        }

        [GetValue]
        public string GetValue()
        {
            return commonScriptLibrary.GetValue(Locator);
        }

        [SetValue]
        public void SetValue(string value)
        {
            context.SetValue(Locator, value);
        }

        [GetValidationMessage]
        public string GetValidationMessage()
        {
            var validationMessageLocator = Locator + ValidationMessagePostfixLocator;
            if (context.GetElementCount(validationMessageLocator) > 0)
            {
                return context.GetText(validationMessageLocator);
            }
            else
            {
                return null;
            }
        }
    }
}