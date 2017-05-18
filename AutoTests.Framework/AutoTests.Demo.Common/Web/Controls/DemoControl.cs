using AutoTests.Framework.Web;

namespace AutoTests.Demo.Common.Web.Controls
{
    public abstract class DemoControl : Control
    {
        protected DemoContext Context { get; }

        protected DemoControl(DemoContext context)
        {
            Context = context;
        }
    }
}