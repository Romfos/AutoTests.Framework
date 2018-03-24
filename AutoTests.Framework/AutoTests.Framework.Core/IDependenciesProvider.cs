namespace AutoTests.Framework.Core
{
    public interface IDependenciesProvider
    {
        T GetDependencies<T>() where T : Dependencies;
    }
}