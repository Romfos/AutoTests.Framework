using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Web.Common.Handlers
{
    public class Enabled : Handler
    {
        public override object Trigger(HandlerArgs args)
        {
            if ((bool)args.Invoke())
            {
                return args.PropertyLink;
            }
            return null;
        }
    }
}