using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Web.Attributes;

namespace AutoTests.Framework.Web.Configurators
{
    public class ElementLocatorConfigurator
    {
        private readonly ConfiguratorsDependencies dependencies;

        public ElementLocatorConfigurator(ConfiguratorsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public virtual void Configure(Element element, string locator)
        {
            var property = GetTargetProperty(element);
            property.SetValue(element, locator);
        }

        private PropertyInfo GetTargetProperty(Element element)
        {
            var property = FindLocatorProperty(element);
            CheckPropertyAttribute(element, property);
            CheckPropertyType(property);
            return property;
        }

        private PropertyInfo FindLocatorProperty(Element element)
        {
            return dependencies.PageObjectPropertiesProvider.GetAllProperties(element)
                .SingleOrDefault(x => x.GetCustomAttributes<FromLocatorAttribute>().Any());
        }

        private void CheckPropertyAttribute(Element element, PropertyInfo property)
        {
            if (property == null)
            {
                throw new ClassConstraintException(element.GetType(),
                    $"Element '{{0}}' should contains property with '{nameof(FromLocatorAttribute)}' attribute");
            }
        }

        private void CheckPropertyType(PropertyInfo property)
        {
            if (property.PropertyType != typeof(string))
            {
                throw new PropertyConstraintException(property,
                    $"Property '{{0}}' should be string type");
            }
        }
    }
}