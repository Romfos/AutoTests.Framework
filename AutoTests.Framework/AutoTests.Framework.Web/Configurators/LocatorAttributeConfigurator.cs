using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Web.Attributes;

namespace AutoTests.Framework.Web.Configurators
{
    public class LocatorAttributeConfigurator
    {
        private readonly ConfiguratorsDependencies dependencies;

        public LocatorAttributeConfigurator(ConfiguratorsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public virtual void Configure(PageObject pageObject)
        {
            var properties = dependencies.PageObjectPropertiesProvider.GetPageElementProperties(pageObject);
            ConfigureElements(pageObject, properties);
        }

        private void ConfigureElements(PageObject pageObject, IEnumerable<PropertyInfo> properties)
        {
            foreach (var property in properties)
            {
                ConfigureElementIfNeeded(pageObject, property);
            }
        }

        private void ConfigureElementIfNeeded(PageObject pageObject, PropertyInfo property)
        {
            var attribute = property.GetCustomAttributes<LocatorAttribute>().SingleOrDefault();
            if (attribute != null)
            {
                var element = (Element) property.GetValue(pageObject);
                dependencies.ElementLocatorConfigurator.Configure(element, attribute.Locator);
            }
        }
    }
}