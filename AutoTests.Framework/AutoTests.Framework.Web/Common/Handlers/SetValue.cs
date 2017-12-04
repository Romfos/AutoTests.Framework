using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Web.Common.Handlers
{
    public class SetValue : Handler
    {
        public override object Trigger(HandlerArgs args)
        {
            args.Invoke(args.PropertyLink.Value);
            return null;
        }
    }
}