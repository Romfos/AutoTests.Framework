using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Web.Configurators
{
    public class LocatorsConfigurator
    {
        private readonly ConfiguratorsDependencies dependencies;

        public LocatorsConfigurator(ConfiguratorsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public virtual string LocatorsFileName => "Locators.json";

        public virtual void Configure(PageObject pageObject)
        {
            if (DoLocatorsExist(pageObject))
            {
                ConfigureLocators(pageObject);
            }
        }

        private void ConfigureLocators(PageObject pageObject)
        {
            var properties = dependencies.PageObjectPropertiesProvider.GetAllProperties(pageObject).ToList();
            var locators = dependencies.Utils.Resources.GetJsonResource(pageObject, LocatorsFileName);
            ConfigureLocators(pageObject, properties, locators);
        }

        private void ConfigureLocators(PageObject pageObject, List<PropertyInfo> properties, JObject locators)
        {
            foreach (var propertyName in GetNodeNames(locators))
            {
                ConfigureLocators(pageObject, properties, locators, propertyName);
            }
        }

        private void ConfigureLocators(PageObject pageObject, List<PropertyInfo> properties, JObject locators, string propertyName)
        {
            var property = properties.SingleOrDefault(x => x.Name == propertyName);
            CheckProperty(pageObject, propertyName, property);
            var token = locators.GetValue(propertyName);
            ConfigureLocators(pageObject, property, token);
        }

        private void ConfigureLocators(PageObject pageObject, PropertyInfo property, JToken token)
        {
            if (property.PropertyType.IsSubclassOf(typeof(Element)))
            {
                ConfigureElementLocators(pageObject, property, token);
            }
            else
            {
                ConfigureObjectProperty(pageObject, property, token);
            }
        }

        private void ConfigureElementLocators(PageObject pageObject, PropertyInfo property, JToken token)
        {
            var element = (Element) property.GetValue(pageObject);
            ConfigureLocators(element, token);
        }

        private void ConfigureObjectProperty(PageObject pageObject, PropertyInfo property, JToken token)
        {
            property.SetValue(pageObject, token.ToObject(property.PropertyType));
        }

        private void ConfigureLocators(Element element, JToken locators)
        {
            if (locators.Type == JTokenType.String)
            {
                dependencies.ElementLocatorConfigurator.Configure(element, locators.ToObject<string>());
            }
            else
            {
                ConfigureMultipleLocators(element, locators);
            }
        }

        private void ConfigureMultipleLocators(Element element, JToken locators)
        {
            var properties = dependencies.PageObjectPropertiesProvider.GetAllProperties(element).ToList();
            foreach (var propertyName in GetNodeNames(locators.ToObject<JObject>()))
            {
                ConfigureLocators(element, propertyName, locators, properties);
            }
        }

        private void ConfigureLocators(Element element, string propertyName, JToken locators, List<PropertyInfo> properties)
        {
            var property = properties.SingleOrDefault(x => x.Name == propertyName);
            CheckProperty(element, propertyName, property);
            var locator = locators[propertyName].ToObject(property.PropertyType);
            property.SetValue(element, locator);
        }

        private void CheckProperty(PageObject pageObject, string propertyName, PropertyInfo property)
        {
            if (property == null)
            {
                throw new ClassConstraintException(pageObject.GetType(),
                    $"PageObject '{{0}}' doesn't contain property with name {propertyName}. Check your Locators.json");
            }
        }

        private IEnumerable<string> GetNodeNames(JObject locators)
        {
            return locators.Properties().Select(x => x.Name);
        }

        private bool DoLocatorsExist(PageObject pageObject)
        {
            return dependencies.Utils.Resources.CheckResource(pageObject, LocatorsFileName);
        }
    }
}