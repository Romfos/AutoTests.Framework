using AutoTests.Framework.Core;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Components.Services
{
    public class NestedComponentsService
    {
        private readonly IContainer container;

        public NestedComponentsService(IContainer container)
        {
            this.container = container;
        }

        public virtual void InitializeComponent(Component component)
        {
            foreach (var property in GetSubComponentProperties(component))
            {
                var nestedCompnent = container.Create(property.PropertyType);
                property.SetValue(component, nestedCompnent);
            }
        }

        private IEnumerable<PropertyInfo> GetSubComponentProperties(Component component)
        {
            return component.GetType().GetProperties()
                .Where(x => x.PropertyType.IsSubclassOf(typeof(Component)))
                .Where(x => x.CanWrite && x.CanRead);
        }
    }
}
