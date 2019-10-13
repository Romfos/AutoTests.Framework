using AutoTests.Framework.Components.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Components.Utils
{
    public class ComponentReflectionUtils
    {
        public IEnumerable<PropertyInfo> GetPropertiesWithGetttersAndSetters(Component component)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            return component.GetType().GetProperties(bindingFlags).Where(x => x.CanWrite && x.CanRead);
        }

        public IEnumerable<PropertyInfo> GetComponentProperties(Component component)
        {
            return GetPropertiesWithGetttersAndSetters(component).Where(x => x.PropertyType.IsSubclassOf(typeof(Component)));
        }

        public PropertyInfo GetPrimaryProperty(Component component)
        {
            return GetPropertiesWithGetttersAndSetters(component)
                .Where(x => x.GetCustomAttributes<PrimaryAttribute>().SingleOrDefault() != null)
                .Single();
        }
    }
}
