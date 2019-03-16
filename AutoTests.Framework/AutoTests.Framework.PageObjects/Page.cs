namespace AutoTests.Framework.PageObjects
{
    public abstract class Page : PageObject
    {
        protected Page(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}