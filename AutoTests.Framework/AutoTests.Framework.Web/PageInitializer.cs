using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Web.Attributes;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Web
{
    public class PageInitializer
    {
        private readonly WebDependencies dependencies;

        public PageInitializer(WebDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public virtual void Initialize(Page page)
        {
            CheckPageConstraints(page);
            SetupElements(page);
        }

        protected virtual void SetupElements(Page page)
        {
            var properties = GetPageElementProperties(page);
            CreateElements(page, properties);
            if (dependencies.Utils.Resources.CheckResource(page, "Locators.json"))
            {
                SetupLocators(page, properties);
            }

            SetupLocatorAttributes(page, properties);
        }

        protected virtual void CreateElements(Page page, PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                property.SetValue(page, dependencies.CreateElement(property.PropertyType));
            }
        }

        protected virtual void SetupLocators(Page page, PropertyInfo[] properties)
        {
            var locators = dependencies.Utils.Resources.GetJsonResource(page, "Locators.json");

            foreach (var name in locators.Properties().Select(x => x.Name))
            {
                var property = properties.First(x => x.Name == name);
                var arguments = locators[name];
                var element = (Element) property.GetValue(page);
                SetElementProperties(element, arguments);
                property.SetValue(page, element);
            }
        }

        protected virtual void SetupLocatorAttributes(Page page, PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes().OfType<LocatorAttribute>().SingleOrDefault();
                if (attribute != null)
                {
                    var element = (Element) property.GetValue(page);
                    var elementProperties = GetElementArgumentProperties(element);
                    if (elementProperties.Length > 1)
                    {
                        throw new ClassConstraintException(element.GetType(),
                            "Element '{0}' should contain single property");
                    }

                    elementProperties.Single().SetValue(element, attribute.Locator);
                }
            }
        }

        protected virtual void SetElementProperties(Element element, JToken arguments)
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

        protected virtual void CheckPageConstraints(Page page)
        {
            foreach (var property in GetPageElementProperties(page))
            {
                if (!property.CanWrite || !property.CanRead)
                {
                    throw new PropertyConstraintException(property, "Property '{0}' should contain setter and getter");
                }
            }
        }

        protected virtual PropertyInfo[] GetElementArgumentProperties(Element element)
        {
            return element.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => !x.GetIndexParameters().Any())
                .Where(x => x.CanRead && x.CanWrite && x.SetMethod.IsPrivate)
                .ToArray();
        }

        protected virtual PropertyInfo[] GetPageElementProperties(Page page)
        {
            return page.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(x => !x.GetIndexParameters().Any())
                .ToArray();
        }

        protected virtual BindingFlags GetBindingFlags()
        {
            return BindingFlags.Instance
                   | BindingFlags.GetProperty
                   | BindingFlags.SetProperty
                   | BindingFlags.Public
                   | BindingFlags.NonPublic;
        }
    }
}