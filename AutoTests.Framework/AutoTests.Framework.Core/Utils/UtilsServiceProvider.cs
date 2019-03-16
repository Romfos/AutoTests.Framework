using BoDi;

namespace AutoTests.Framework.Core.Utils
{
    public class UtilsServiceProvider : ServiceProvider
    {
        public UtilsServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public EmbeddedResourcesUtils EmbeddedResourcesUtils => ObjectContainer.Resolve<EmbeddedResourcesUtils>();
    }
}