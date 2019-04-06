using AutoTests.Framework.PageObjects;

namespace BootstrapTests.Web.Bootstrap.Elements
{
    public abstract class BootstrapElement : Element
    {
        protected Application Application { get; }
        protected BootstrapContext Context { get; }

        protected BootstrapElement(Application application) : base(application.PageObjects)
        {
            Application = application;
            Context = application.GetContext<BootstrapContext>();
        }
    }
}
