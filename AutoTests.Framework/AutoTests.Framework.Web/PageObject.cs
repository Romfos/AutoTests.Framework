namespace AutoTests.Framework.Web
{
    public abstract class PageObject
    {
        protected PageObject(WebDependencies dependencies)
        {
            dependencies.Configurators.PageObjectConfiguratorService.Configure(this);
        }
    }
}