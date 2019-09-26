using AutoTests.Framework.Web.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Web.Services
{
    public class ComponentContentAttributeService
    {
        public virtual void InitializeComponent(Component component)
        {
            foreach(var propertyInfo in GetComponentProperties(component))
            {
                var nestedComponent = GetNestedComponent(component, propertyInfo);
                var contentData = GetConentAttributeData(propertyInfo);
                var primaryProperty = GetPrimaryProperty(nestedComponent);
                primaryProperty.SetValue(nestedComponent, contentData);
            }
        }

        private Component GetNestedComponent(Component component, PropertyInfo propertyInfo)
        {
            return (Component)propertyInfo.GetValue(component);
        }

        private PropertyInfo GetPrimaryProperty(Component component)
        {
            return component.GetType().GetProperties()
                .Where(x => x.CanWrite && x.CanRead)
                .Where(x => x.GetCustomAttributes<PrimaryAttribute>().SingleOrDefault() != null)
                .Single();
        }

        private IEnumerable<PropertyInfo> GetComponentProperties(Component component)
        {
            return component.GetType().GetProperties()
                .Where(x => x.CanWrite && x.CanRead)
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Component)))
                .Where(x => x.GetCustomAttributes<ContentAttribute>().SingleOrDefault() != null);
        }

        private string GetConentAttributeData(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<ContentAttribute>().Data;
        }
    }
}
