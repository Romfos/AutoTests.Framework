using AutoTests.Framework.Web;

namespace AutoTests.Framework.Tests.Web.Controls
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