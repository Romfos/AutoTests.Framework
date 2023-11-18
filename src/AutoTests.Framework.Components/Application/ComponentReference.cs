using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Components.Application;

public sealed class ComponentReference(ComponentService componentService, string path)
{
    public T GetComponent<T>()
        where T : class
    {
        return componentService.GetComponent<T>(path);
    }
}
