using AutoTests.Framework.Web;

namespace AutoTests.Framework.Example.Web.Pages
{
    public abstract class BootstrapPage : Page
    {
        protected readonly Application application;

        protected BootstrapPage(Application application) : base(application.Web)
        {
            this.application = application;
        }
    }
}