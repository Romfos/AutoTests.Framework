using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Web.Common.Handlers
{
    public class GetValue : Handler
    {
        public override object Trigger(HandlerArgs args)
        {
            args.PropertyLink.Value = args.Invoke();
            return null;
        }
    }
}