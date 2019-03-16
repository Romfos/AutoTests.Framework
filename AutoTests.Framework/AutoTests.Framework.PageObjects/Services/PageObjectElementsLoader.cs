using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.PageObjects.Services
{
    public class PageObjectElementsLoader
    {
        private readonly PageObjectsServiceProvider serviceProvider;

        public PageObjectElementsLoader(PageObjectsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual void LoadPageObjectElements(PageObject pageObject)
        {
            foreach (var property in GetElementProperties(pageObject))
            {
                var element = serviceProvider.CreateElement(property.PropertyType);
                LoadPageObjectElements(element);
                property.SetValue(pageObject, element);
            }
        }

        private IEnumerable<PropertyInfo> GetElementProperties(PageObject pageObject)
        {
            return pageObject.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(x => x.CanWrite && x.CanRead && !x.GetIndexParameters().Any());
        }
        
        private BindingFlags GetBindingFlags()
        {
            return BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        }
    }
}