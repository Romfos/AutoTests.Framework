using AutoTests.Framework.Web;

namespace AutoTests.Framework.Tests.Web.Elements
{
    public abstract class DemoElement : Element
    {
        protected DemoContext Context { get; }

        protected DemoElement(DemoContext context)
        {
            Context = context;
        }
    }
}