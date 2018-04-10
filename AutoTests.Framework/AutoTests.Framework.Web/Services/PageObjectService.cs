using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Web.Services
{
    public class PageObjectService
    {
        public PageObjectService(ConfiguratorsDependencies dependencies)
        {
            
        }

        public IEnumerable<PropertyInfo> GetAllProperties(PageObject pageObject)
        {
            return pageObject.GetType().GetProperties(GetBindingFlags());
        }

        public virtual IEnumerable<PropertyInfo> GetPageElementProperties(PageObject pageObject)
        {
            return pageObject.GetType()
                .GetProperties(GetBindingFlags())
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Element)))
                .Where(x => !x.GetIndexParameters().Any());
        }

        private BindingFlags GetBindingFlags()
        {
            return BindingFlags.Instance
                   | BindingFlags.GetProperty
                   | BindingFlags.SetProperty
                   | BindingFlags.Public
                   | BindingFlags.NonPublic;
        }
    }
}