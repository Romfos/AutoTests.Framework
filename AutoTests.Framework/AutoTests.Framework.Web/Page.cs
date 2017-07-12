using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Web.Attributes;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Web
{
    public abstract class Page : PageObject
    {
        private readonly WebDependencies dependencies;

        protected Page(WebDependencies dependencies)
        {
            this.dependencies = dependencies;
            CheckConstraints();
            SetupElements();
        }

        private void SetupElements()
        {
            var properties = GetPageElementProperties();
            CreateElements(properties);
            if (dependencies.Utils.Resources.CheckResource(this, "Locators.json"))
            {
                SetupLocators(properties);
            }
            SetupLocatorAttributes(properties);
        }

        private void CreateElements(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                property.SetValue(this, dependencies.CreateElement(property.PropertyType));
            }
        }

        private void SetupLocators(PropertyInfo[] properties)
        {
            var locators = dependencies.Utils.Resources.GetJsonResource(this, "Locators.json");
            
            foreach (var name in locators.Properties().Select(x => x.Name))
            {
                var property = properties.First(x => x.Name == name);
                var arguments = locators[name];
                var element = (Element)property.GetValue(this);
                SetElementProperties(element, arguments);
                property.SetValue(this, element);
            }
        }

        private void SetupLocatorAttributes(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes().OfType<LocatorAttribute>().SingleOrDefault();
                if (attribute != null)
                {
                    var element = (Element) property.GetValue(this);
                    var elementProperties = GetElementArgumentProperties(element);
                    if (elementProperties.Length > 1)
                    {
                        throw new ClassConstraintException(element.GetType(), "Element '{0}' should contain single property");
                    }
                    elementProperties.Single().SetValue(element, attribute.Locator);
                }
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
            return element.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => !x.GetIndexParameters().Any())
                .Where(x => x.CanRead && x.CanWrite && x.SetMethod.IsPrivate)
                .ToArray();
        }

        private PropertyInfo[] GetPageElementProperties()
        {
            return GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(x => !x.GetIndexParameters().Any())
                .ToArray();
        }

        private BindingFlags GetBindingFlags()
        {
            return BindingFlags.Instance
                   | BindingFlags.GetProperty
                   | BindingFlags.SetProperty
                   | BindingFlags.Public
                   | BindingFlags.NonPublic;
        }

        private void CheckConstraints()
        {
            foreach (var property in GetPageElementProperties())
            {
                if (!property.CanWrite || !property.SetMethod.IsPrivate)
                {
                    throw new PropertyConstraintException(property, "Property '{0}' should contain private setter");
                }
            }
        }
    }
}