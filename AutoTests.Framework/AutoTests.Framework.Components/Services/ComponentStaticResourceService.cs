using AutoTests.Framework.Core.Utils;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Components.Utils;
using AutoTests.Framework.Core.Exceptions;
using System.Text.Json;

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
                using var jsonDocument = JsonDocument.Parse(content);
                SetResourceValuesToComponent(component, jsonDocument.RootElement);
            }
        }

        private void SetResourceValuesToComponent(Component component, JsonElement jsonElement)
        {
            var propertyInfos = componentReflectionUtils.GetPropertiesWithGetttersAndSetters(component).ToList();
            foreach(var jsonProperty in jsonElement.EnumerateObject())
            {
                var propertyInfo = propertyInfos.SingleOrDefault(x => x.Name == jsonProperty.Name);
                if(propertyInfo == null)
                {
                    throw new AutoTestFrameworkException(
                        $"Unable to find property '{jsonProperty.Name}' in component '{component.GetType().FullName}'");
                }
                SetResourceValueToComponent(component, propertyInfo, jsonProperty.Value);
            }
        }

        private void SetResourceValueToComponent(Component component, PropertyInfo propertyInfo, JsonElement jsonElement)
        {
            if (propertyInfo.PropertyType.IsSubclassOf(typeof(Component)))
            {
                var nestedComponent = GetNestedComponent(component, propertyInfo);
                if (jsonElement.ValueKind == JsonValueKind.Object)
                {
                    SetResourceValuesToComponent(nestedComponent, jsonElement);
                }
                else
                {
                    var primaryProperty = componentReflectionUtils.GetPrimaryProperty(nestedComponent);
                    SetPropertyValue(nestedComponent, primaryProperty, jsonElement);
                }
            }
            else
            {
                SetPropertyValue(component, propertyInfo, jsonElement);
            }
        }

        private Component GetNestedComponent(Component component, PropertyInfo propertyInfo)
        {
            return (Component) propertyInfo.GetValue(component)!;
        }

        private void SetPropertyValue(Component component, PropertyInfo propertyInfo, JsonElement jsonElement)
        {
            var value = JsonSerializer.Deserialize(jsonElement.GetRawText(), propertyInfo.PropertyType);
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
