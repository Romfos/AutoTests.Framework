using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Common;

namespace AutoTests.Framework.Example.Web.Elements
{
    public class BootstrapElement : Element
    {
        protected readonly Application application;
        protected readonly CommonContext context;

        public BootstrapElement(Application application) : base(application.Web)
        {
            this.application = application;
            context = application.Web.GetContext<CommonContext>();
        }
    }
}