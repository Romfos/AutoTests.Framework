using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Web
{
    public abstract class Page
    {
        private readonly WebDependencies dependencies;

        protected Page(WebDependencies dependencies)
        {
            this.dependencies = dependencies;
            CheckConstraints();
            CreateElements();
        }

        private void CreateElements()
        {
            var locators = dependencies.Utils.Resources.GetJsonResource(this, "Locators.json");

            foreach (var property in GetPageElementProperties())
            {
                var arguments = locators[property.Name];
                var element = dependencies.CreateElement(property.PropertyType);
                SetElementProperties(element, arguments);
                property.SetValue(this, element);
            }
        }

        private void SetElementProperties(Element element, JToken arguments)
        {
            var properties = GetElementArgumentProperties(element);
            if (properties.Length == 1)
            {
                var property = properties[0];
                property.SetValue(element, arguments.ToObject(property.PropertyType));
            }
            if (properties.Length > 1)
            {
                foreach (var property in properties)
                {
                    property.SetValue(element, arguments[property.Name].ToObject(property.PropertyType));
                }
            }
        }

        private PropertyInfo[] GetElementArgumentProperties(Element element)
        {
            var bindingFlags = BindingFlags.Instance
                               | BindingFlags.GetProperty
                               | BindingFlags.SetProperty
                               | BindingFlags.Public
                               | BindingFlags.NonPublic;

            return element.GetType()
                .GetProperties(bindingFlags)
                .Where(x => !x.GetIndexParameters().Any())
                .Where(x => x.CanRead && x.CanWrite && x.SetMethod.IsPrivate)
                .ToArray();
        }

        private IEnumerable<PropertyInfo> GetPageElementProperties()
        {
            var bindingFlags = BindingFlags.Instance
                               | BindingFlags.GetProperty
                               | BindingFlags.SetProperty
                               | BindingFlags.Public
                               | BindingFlags.NonPublic;

            return GetType()
                .GetProperties(bindingFlags)
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(x => !x.GetIndexParameters().Any());
        }

        private void CheckConstraints()
        {
            if (!dependencies.Utils.Resources.CheckResource(this, "Locators.json"))
            {
                throw new ClassConstraintException(GetType(),
                    "Locators.json not found. Page '{0}'");
            }

            foreach (var property in GetPageElementProperties())
            {
                if (!property.CanWrite || !property.SetMethod.IsPrivate)
                {
                    throw new PropertyConstraintException(property,
                        "Property '{0}' should contain private setter");
                }
            }
        }
    }
}