using AutoTests.Framework.Web;

namespace AutoTests.Web.Pages
{
    public abstract class SemanticPage : Page
    {
        protected Application Application { get; }

        protected SemanticPage(Application application)
            : base(application.Web)
        {
            Application = application;
        }
    }
}