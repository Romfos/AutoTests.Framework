using AutoTests.Framework.Configuration.ConfigurationLoaders;
using AutoTests.Framework.Core;
using System;

namespace AutoTests.Framework.Configuration
{
    public static class FrameworkModuleBuilder
    {
        public static AutoTestsFrameworkBuilder UseConfiguration<T>(
               this AutoTestsFrameworkBuilder autoTestsFrameworkBuilder, Action<T> loader)
            where T : ConfigurationLoader
        {
            return autoTestsFrameworkBuilder.Use(x =>
            {
                var configurationServiceProvider = x.Resolve<ConfigurationServiceProvider>();
                var configurationLoader = configurationServiceProvider.GetConfigurationLoader<T>();
                loader(configurationLoader);
            });
        }
    }
}
