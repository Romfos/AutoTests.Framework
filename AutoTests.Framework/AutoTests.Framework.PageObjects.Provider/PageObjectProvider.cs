using System.Linq;
using System.Reflection;
using AutoTests.Framework.PageObjects.Provider.Attributes;

namespace AutoTests.Framework.PageObjects.Provider
{
    public class PageObjectProvider
    {
        private readonly PageObjectProviderServiceProvider serviceProvider;

        public PageObjectProvider(PageObjectProviderServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public PageObject Request(PageObjectQuery query)
        {
            PageObject pageObject = serviceProvider.GetPage(query.PrimaryPageName);
            foreach (var pageObjectName in query.NestedPageObjectNames)
            {
                pageObject = GetNestedPageObject(pageObject, pageObjectName);
            }
            return pageObject;
        }

        private PageObject GetNestedPageObject(PageObject pageObject, string pageObjectName)
        {
            return pageObject.GetType().GetProperties()
                .Where(x => x.PropertyType.IsSubclassOf(typeof(PageObject)))
                .Where(x => x.CanRead)
                .Where(x => x.GetCustomAttributes(true).OfType<PageObjectNameAttribute>()
                    .Any(y => y.Name == pageObjectName))
                .Select(x => (PageObject) x.GetValue(pageObject))
                .Single();
        }

        private BindingFlags GetBindingFlags()
        {
            return BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        }
    }
}