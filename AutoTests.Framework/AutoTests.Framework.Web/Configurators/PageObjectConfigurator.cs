namespace AutoTests.Framework.Web.Configurators
{
    public class PageObjectConfigurator
    {
        private readonly ConfiguratorsDependencies dependencies;

        public PageObjectConfigurator(ConfiguratorsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public virtual void Configure(PageObject pageObject)
        {
            dependencies.ElementFactory.CreateElements(pageObject);
            dependencies.LocatorsConfigurator.Configure(pageObject);
            dependencies.LocatorAttributeConfigurator.Configure(pageObject);
        }
    }
}