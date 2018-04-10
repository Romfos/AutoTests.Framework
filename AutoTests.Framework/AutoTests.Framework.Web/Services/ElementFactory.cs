using System.Collections.Generic;
using System.Reflection;

namespace AutoTests.Framework.Web.Services
{
    public class ElementFactory
    {
        private readonly ConfiguratorsDependencies dependencies;

        public ElementFactory(ConfiguratorsDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public void CreateElements(PageObject pageObject)
        {
            var properties = dependencies.PageObjectService.GetPageElementProperties(pageObject);
            CreatePageObjectElements(pageObject, properties);
        }

        private void CreatePageObjectElements(PageObject pageObject, IEnumerable<PropertyInfo> properties)
        {
            foreach (var property in properties)
            {
                CreatePageObjectElement(pageObject, property);
            }
        }

        private void CreatePageObjectElement(PageObject pageObject, PropertyInfo property)
        {
            var element = dependencies.CreateElement(property.PropertyType);
            property.SetValue(pageObject, element);
        }
    }
}