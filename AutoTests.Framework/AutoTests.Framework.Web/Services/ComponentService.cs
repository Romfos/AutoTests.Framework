using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Web.Services
{
    public class ComponentService
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;
        private readonly IContainer container;

        public ComponentService(EmbeddedResourceUtils embeddedResourceUtils, IContainer container)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
            this.container = container;
        }

        public virtual void InitializeComponent(Component component)
        {
            CreateSubComponents(component);
        }

        private void CreateSubComponents(Component component)
        {
            foreach(var property in GetSubComponentProperties(component))
            {
                var subCompnent = container.Create(property.PropertyType);
                property.SetValue(component, subCompnent);
            }
        }

        private IEnumerable<PropertyInfo> GetSubComponentProperties(Component component)
        {
            return component.GetType().GetProperties()
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Component)))
                .Where(x => x.CanWrite && x.CanRead);
        }

        private string GetJsonResourceContent(Component component)
        {
            var type = component.GetType();
            var assembly = type.Assembly;
            var name = $"{type.FullName}.json";
            return embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, name);
        }
    }
}
