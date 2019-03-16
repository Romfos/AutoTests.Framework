using System.Reflection;
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
            var property = serviceProvider.PageObjectReflectionService.GetProperty(pageObject, jProperty.Name);
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
                var primaryLocatorProperty = serviceProvider.PageObjectReflectionService
                    .GetPrimaryLocatorProperty(element);
                var value = locatorProperty.Value.ToObject(primaryLocatorProperty.PropertyType);
                primaryLocatorProperty.SetValue(element, value);
            }
        }
    }
}