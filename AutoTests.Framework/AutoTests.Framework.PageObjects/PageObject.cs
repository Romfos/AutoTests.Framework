namespace AutoTests.Framework.PageObjects
{
    public abstract class PageObject
    {
        protected PageObject(PageObjectsServiceProvider serviceProvider)
        {
            serviceProvider.PageObjectLoader.LoadPageObject(this);
        }
    }
}