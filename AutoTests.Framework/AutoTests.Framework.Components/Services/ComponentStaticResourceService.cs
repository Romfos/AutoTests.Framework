using AutoTests.Framework.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Components.Utils;
using AutoTests.Framework.Core.Exceptions;

namespace AutoTests.Framework.Components.Services
{
    public class ComponentStaticResourceService
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;
        private readonly ComponentReflectionUtils componentReflectionUtils;

        public ComponentStaticResourceService(
            EmbeddedResourceUtils embeddedResourceUtils, 
            ComponentReflectionUtils componentReflectionUtils)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
            this.componentReflectionUtils = componentReflectionUtils;
        }

        public virtual void InitializeComponent(Component component)
        {
            var content = GetJsonResourceContent(component);
            if(content != null)
            {
                var jObject = JObject.Parse(content);
                SetResourceValuesToComponent(component, jObject);
            }
        }

        private void SetResourceValuesToComponent(Component component, JObject jObject)
        {
            var propertyInfos = componentReflectionUtils.GetPropertiesWithGetttersAndSetters(component).ToList();
            foreach(var jProperty in jObject.Properties())
            {
                var propertyInfo = propertyInfos.SingleOrDefault(x => x.Name == jProperty.Name);
                if(propertyInfo == null)
                {
                    throw new AutoTestFrameworkException(
                        $"Unable to find proeprty '{jProperty.Name}' in component '{component.GetType().FullName}'");
                }
                SetResourceValueToComponent(component, propertyInfo, jProperty);
            }
        }

        private void SetResourceValueToComponent(Component component, PropertyInfo propertyInfo, JProperty jProperty)
        {
            if (propertyInfo.PropertyType.IsSubclassOf(typeof(Component)))
            {
                var nestedComponent = GetNestedComponent(component, propertyInfo);
                if (jProperty.Value.Type == JTokenType.Object)
                {
                    SetResourceValuesToComponent(nestedComponent, jProperty.Value.ToObject<JObject>());
                }
                else
                {
                    var primaryProperty = componentReflectionUtils.GetPrimaryProperty(nestedComponent);
                    SetPropertyValue(nestedComponent, primaryProperty, jProperty);
                }
            }
            else
            {
                SetPropertyValue(component, propertyInfo, jProperty);
            }
        }

        private Component GetNestedComponent(Component component, PropertyInfo propertyInfo)
        {
            return (Component) propertyInfo.GetValue(component)!;
        }

        private void SetPropertyValue(Component component, PropertyInfo propertyInfo, JProperty jProperty)
        {
            var value = jProperty.ToObject(propertyInfo.PropertyType);
            propertyInfo.SetValue(component, value);
        }

        private string? GetJsonResourceContent(Component component)
        {
            var type = component.GetType();
            var assembly = type.Assembly;
            var name = $"{type.FullName}.json";

            var content = embeddedResourceUtils.DoesLocalEmbeddedResourceExist(assembly, name)
                ? embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, name)
                : null;

            return content;
        }
    }
}
