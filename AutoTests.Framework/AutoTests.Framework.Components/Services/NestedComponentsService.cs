using AutoTests.Framework.Components.Utils;
using AutoTests.Framework.Core;

namespace AutoTests.Framework.Components.Services;

public class NestedComponentsService
{
    private readonly ComponentReflectionUtils componentReflectionUtils;
    private readonly IContainer container;

    public NestedComponentsService(IContainer container, ComponentReflectionUtils componentReflectionUtils)
    {
        this.container = container;
        this.componentReflectionUtils = componentReflectionUtils;
    }

    public virtual void InitializeComponent(Component component)
    {
        foreach (var propertyInfo in componentReflectionUtils.GetComponentProperties(component))
        {
            var nestedCompnent = container.Create(propertyInfo.PropertyType);
            propertyInfo.SetValue(component, nestedCompnent);
        }
    }
}
