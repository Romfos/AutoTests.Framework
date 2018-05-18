using AutoTests.Framework.Example.Web.Attributes;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Example.Web.Handlers
{
    public class GetValidationMessage : Handler
    {
        public override object Trigger(HandlerArgs args)
        {
            var message = (string) args.Invoke();
            args.PropertyLink.RemoveAttribute<ValidationMessageAttribute>();
            args.PropertyLink.Attributes.Add(new ValidationMessageAttribute(message));
            return null;
        }
    }
}