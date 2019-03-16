namespace AutoTests.Framework.PageObjects.Services
{
    public class PageObjectLoader
    {
        private readonly PageObjectsServiceProvider serviceProvider;

        public PageObjectLoader(PageObjectsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual void LoadPageObject(PageObject pageObject)
        {
            serviceProvider.PageObjectElementsLoader.LoadPageObjectElements(pageObject);
        }
    }
}