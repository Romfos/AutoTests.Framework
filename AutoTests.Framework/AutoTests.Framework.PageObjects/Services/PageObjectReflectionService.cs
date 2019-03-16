using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.PageObjects.Attributes;

namespace AutoTests.Framework.PageObjects.Services
{
    public class PageObjectReflectionService
    {
        public PageObjectReflectionService(PageObjectsServiceProvider serviceProvider)
        {

        }

        public PropertyInfo GetProperty(PageObject pageObject, string name)
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

        public PropertyInfo GetPrimaryLocatorProperty(Element element)
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

        public IEnumerable<PropertyInfo> GetLocatorProperties(PageObject pageObject)
        {
            return pageObject.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(IsValidProperty)
                .Where(x => x.GetCustomAttributes(true).OfType<LocatorAttribute>().Any());
        }

        public IEnumerable<PropertyInfo> GetElementProperties(PageObject pageObject)
        {
            return pageObject.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(IsValidProperty);
        }

        private PropertyInfo GetPageObjectProperty(PageObject pageObject, string name)
        {
            return pageObject.GetType()
                .GetProperties(GetBindingFlags())
                .SingleOrDefault(x => x.Name == name);
        }

        private PropertyInfo PrimaryLocatorProperty(Element element)
        {
            return element.GetType().GetProperties(GetBindingFlags())
                .SingleOrDefault(x => x.GetCustomAttributes(true).OfType<PrimaryLocatorAttribute>().Any());
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