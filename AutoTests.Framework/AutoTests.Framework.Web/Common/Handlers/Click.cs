using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Web.Common.Handlers
{
    public class Click : Handler
    {
        public override object Trigger(HandlerArgs args)
        {
            args.Invoke();
            return null;
        }
    }
}