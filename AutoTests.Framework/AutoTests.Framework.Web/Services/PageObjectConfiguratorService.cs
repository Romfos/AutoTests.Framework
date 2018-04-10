namespace AutoTests.Framework.Web.Services
{
    public class PageObjectConfiguratorService
    {
        private readonly ConfiguratorsDependencies dependencies;

        public PageObjectConfiguratorService(ConfiguratorsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public virtual void Configure(PageObject pageObject)
        {
            dependencies.ElementFactory.CreateElements(pageObject);
            dependencies.LocatorsJsonService.Configure(pageObject);
            dependencies.LocatorAttributeService.Configure(pageObject);
        }
    }
}