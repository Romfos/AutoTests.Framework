using AutoTests.Framework.Web;
using AutoTests.Framework.Web.Common;
using AutoTests.Framework.Web.Common.Scripts;

namespace AutoTests.Framework.Example.Web.Elements
{
    public class BootstrapElement : Element
    {
        protected readonly Application application;
        protected readonly CommonContext context;
        protected readonly CommonScriptLibrary commonScriptLibrary;

        public BootstrapElement(Application application) : base(application.Web)
        {
            this.application = application;
            context = application.Web.GetContext<CommonContext>();
            commonScriptLibrary = application.Web.GetScriptLibrary<CommonScriptLibrary>();
        }
    }
}