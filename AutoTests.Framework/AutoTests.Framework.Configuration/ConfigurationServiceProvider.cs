using AutoTests.Framework.Configuration.ConfigurationLoaders;
using AutoTests.Framework.Core;
using BoDi;

namespace AutoTests.Framework.Configuration
{
    public class ConfigurationServiceProvider : ServiceProvider
    {
        public ConfigurationServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ConfigurationProvider ConfigurationProvider => ObjectContainer.Resolve<ConfigurationProvider>();

        public T GetConfigurationLoader<T>()
            where T: ConfigurationLoader
        {
            return ObjectContainer.Resolve<T>();
        }
    }
}
