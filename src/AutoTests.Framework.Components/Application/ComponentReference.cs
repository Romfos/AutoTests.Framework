using AutoTests.Framework.Components.Services;

namespace AutoTests.Framework.Components.Application;

public sealed class ComponentReference
{
    private readonly ComponentService componentService;
    private readonly string path;

    public ComponentReference(ComponentService componentService, string path)
    {
        this.componentService = componentService;
        this.path = path;
    }

    public T GetComponent<T>()
        where T : class
    {
        return componentService.GetComponent<T>(path);
    }
}
