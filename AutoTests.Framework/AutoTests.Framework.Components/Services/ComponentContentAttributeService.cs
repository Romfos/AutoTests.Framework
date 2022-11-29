using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Components.Services;

    public class ComponentContentAttributeService
    {
        private readonly ComponentReflectionUtils componentReflectionUtils;

        public ComponentContentAttributeService(ComponentReflectionUtils componentReflectionUtils)
        {
            this.componentReflectionUtils = componentReflectionUtils;
        }

        public virtual void InitializeComponent(Component component)
        {
            foreach(var propertyInfo in GetContentComponentProperties(component))
            {
                var nestedComponent = GetNestedComponent(component, propertyInfo);
                var contentData = GetConentAttributeData(propertyInfo);
                var primaryProperty = componentReflectionUtils.GetPrimaryProperty(nestedComponent);
                primaryProperty.SetValue(nestedComponent, contentData);
            }
        }

        private Component GetNestedComponent(Component component, PropertyInfo propertyInfo)
        {
            return (Component)propertyInfo.GetValue(component)!;
        }

        private IEnumerable<PropertyInfo> GetContentComponentProperties(Component component)
        {
            return componentReflectionUtils.GetComponentProperties(component)
                .Where(x => x.GetCustomAttributes<ContentAttribute>().SingleOrDefault() != null);
        }

        private string GetConentAttributeData(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<ContentAttribute>()!.Data;
        }
    }
