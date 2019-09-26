using AutoTests.Framework.Core.Utils;
using AutoTests.Framework.Web.Attributes;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Web.Services
{
    public class ComponentStaticResourceService
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;

        public ComponentStaticResourceService(EmbeddedResourceUtils embeddedResourceUtils)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
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
            var properties = GetComponentProperties(component);
            foreach(var jProperty in jObject.Properties())
            {
                var property = properties.Single(x => x.Name == jProperty.Name);
                if(property.PropertyType.IsSubclassOf(typeof(Component)))
                {
                    var nestedComponent = (Component)property.GetValue(component);
                    if (jProperty.Value.Type == JTokenType.Object)
                    {                        
                        SetResourceValuesToComponent(nestedComponent, jProperty.Value.ToObject<JObject>());
                    }
                    else
                    {
                        var primaryProperty = GetPrimaryProperty(nestedComponent);
                        var value = jProperty.ToObject(primaryProperty.PropertyType);
                        primaryProperty.SetValue(nestedComponent, value);
                    }
                }
                else
                {
                    var value = jProperty.ToObject(property.PropertyType);
                    property.SetValue(component, value);
                }
            }
        }

        private PropertyInfo GetPrimaryProperty(Component component)
        {
            return component.GetType().GetProperties()
                .Where(x => x.CanWrite && x.CanRead)
                .Where(x => x.GetCustomAttributes<PrimaryAttribute>().SingleOrDefault() != null)
                .Single();
        }

        private List<PropertyInfo> GetComponentProperties(Component component)
        {
            return component.GetType().GetProperties().Where(x => x.CanWrite && x.CanRead).ToList();
        }

        private string GetJsonResourceContent(Component component)
        {
            var type = component.GetType();
            var assembly = type.Assembly;
            var name = $"{type.FullName}.json";

            return embeddedResourceUtils.DoesLocalEmbeddedResourceContains(assembly, name)
                ? embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, name)
                : null;
        }
    }
}
