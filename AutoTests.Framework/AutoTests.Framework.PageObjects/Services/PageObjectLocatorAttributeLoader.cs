using System;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.PageObjects.Attributes;

namespace AutoTests.Framework.PageObjects.Services
{
    public class PageObjectLocatorAttributeLoader
    {
        private readonly PageObjectsServiceProvider serviceProvider;

        public PageObjectLocatorAttributeLoader(PageObjectsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual void LoadLocatorAttributes(PageObject pageObject)
        {
            var properties = serviceProvider.PageObjectReflectionService.GetLocatorProperties(pageObject);
            foreach (var property in properties)
            {
                var element = (Element) property.GetValue(pageObject);
                var locatorProperty = serviceProvider.PageObjectReflectionService.GetPrimaryLocatorProperty(element);
                var locatorValue = GetLocatorValue(property);
                locatorProperty.SetValue(element, locatorValue);
            }
        }

        private string GetLocatorValue(PropertyInfo property)
        {
            var locatorAttribute = property.GetCustomAttributes(true).OfType<LocatorAttribute>().SingleOrDefault();
            if (locatorAttribute == null)
            {
                throw new Exception(string.Format("Locator attribute for {0} in type {1} must be single",
                    property.Name, property.DeclaringType.FullName));
            }
            return locatorAttribute.Value;
        }
    }
}