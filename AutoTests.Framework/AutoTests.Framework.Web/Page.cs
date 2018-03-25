namespace AutoTests.Framework.Web
{
    public abstract class Page : PageObject
    {
        protected Page(WebDependencies dependencies)
        {
            dependencies.PageInitializer.Initialize(this);
        }
    }
}