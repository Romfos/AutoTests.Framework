namespace AutoTests.Framework.Web
{
    public abstract class Page : PageObject
    {
        protected Page(WebDependencies dependencies) : base(dependencies)
        {
        }
    }
}