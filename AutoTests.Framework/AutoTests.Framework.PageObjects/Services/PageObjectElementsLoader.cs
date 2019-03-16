namespace AutoTests.Framework.PageObjects.Services
{
    public class PageObjectElementsLoader
    {
        private readonly PageObjectsServiceProvider serviceProvider;

        public PageObjectElementsLoader(PageObjectsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual void LoadPageObjectElements(PageObject pageObject)
        {
            var properties = serviceProvider.PageObjectReflectionService.GetElementProperties(pageObject);
            foreach (var property in properties)
            {
                var element = serviceProvider.CreateElement(property.PropertyType);
                serviceProvider.PageObjectLoader.LoadPageObject(element);
                property.SetValue(pageObject, element);
            }
        }
    }
}