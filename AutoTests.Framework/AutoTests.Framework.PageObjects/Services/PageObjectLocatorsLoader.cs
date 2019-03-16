using System;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.PageObjects.Attributes;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.PageObjects.Services
{
    public class PageObjectLocatorsLoader
    {
        private readonly PageObjectsServiceProvider serviceProvider;

        public PageObjectLocatorsLoader(PageObjectsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual void LoadPageObjectLocators(PageObject pageObject)
        {
            if (serviceProvider.Utils.EmbeddedResourcesUtils.IsResourceExist(pageObject, "Locators.json"))
            {
                var jObject = serviceProvider.Utils.EmbeddedResourcesUtils
                    .GetJsonResourceContent(pageObject, "Locators.json");
                LoadPageObjectLocators(pageObject, jObject);
            }
        }

        private void LoadPageObjectLocators(PageObject pageObject, JObject jObject)
        {
            foreach (var jProperty in jObject.Properties())
            {
                LoadPageObjectLocators(pageObject, jProperty);
            }
        }

        private void LoadPageObjectLocators(PageObject pageObject, JProperty jProperty)
        {
            var property = FindProperty(pageObject, jProperty.Name);
            if (property.PropertyType.IsSubclassOf(typeof(Element)))
            {
                LoadLocatorsForNestedElement(pageObject, property, jProperty);
            }
            else
            {
                var value = jProperty.ToObject(property.PropertyType);
                property.SetValue(pageObject, value);
            }
        }

        private void LoadLocatorsForNestedElement(PageObject pageObject, 
            PropertyInfo elementProperty, JProperty locatorProperty)
        {
            var element = (Element)elementProperty.GetValue(pageObject);
            if (locatorProperty.Value.Type == JTokenType.Object)
            {
                LoadPageObjectLocators(element, locatorProperty.Value.ToObject<JObject>());
            }
            else
            {
                var primaryLocatorProperty = FindPrimaryLocatorProperty(element);
                var value = locatorProperty.Value.ToObject(primaryLocatorProperty.PropertyType);
                primaryLocatorProperty.SetValue(element, value);
            }
        }

        private PropertyInfo FindPrimaryLocatorProperty(Element element)
        {
            var property = PrimaryLocatorProperty(element);
            if (property == null)
            {
                throw new Exception($"Primary locator property was not found for {element.GetType().Name} type");
            }
            if (!IsValidProperty(property))
            {
                throw new Exception($"Primary locator property in {element.GetType().Name} type. " +
                                    "Property must contain getter and setter");
            }
            return property;
        }

        private PropertyInfo FindProperty(PageObject pageObject, string name)
        {
            var property = GetPageObjectProperty(pageObject, name);
            if (property == null)
            {
                throw new Exception($"Property '{name}' was not found in {pageObject.GetType().Name} type");
            }
            if (!IsValidProperty(property))
            {
                throw new Exception($"Invalid property '{name}' in {pageObject.GetType().Name} type. " +
                                    "Property must contain getter and setter");
            }
            return property;
        }

        private PropertyInfo PrimaryLocatorProperty(Element element)
        {
            return element.GetType().GetProperties(GetBindingFlags())
                .SingleOrDefault(x => x.GetCustomAttributes(true).OfType<PrimaryLocatorAttribute>().Any());
        }

        private PropertyInfo GetPageObjectProperty(PageObject pageObject, string name)
        {
            return pageObject.GetType()
                .GetProperties(GetBindingFlags())
                .SingleOrDefault(x => x.Name == name);
        }

        private bool IsValidProperty(PropertyInfo property)
        {
            return property.CanWrite && property.CanRead && !property.GetIndexParameters().Any();
        }

        private BindingFlags GetBindingFlags()
        {
            return BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        }
    }
}