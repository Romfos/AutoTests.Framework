namespace AutoTests.Framework.Components.Application;

public interface IComponentReference
{
    T GetComponent<T>() where T : class;
}
