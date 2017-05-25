using AutoTests.Framework.Web;

namespace AutoTests.Web.Controls
{
    public abstract class SemanticControl : Control
    {
        protected Application Application { get; }
        protected SemanticContext Context { get; }

        protected SemanticControl(Application application)
        {
            Application = application;
            Context = application.Web.GetContext<SemanticContext>();
        }
    }
}