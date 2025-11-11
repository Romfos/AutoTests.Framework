namespace AutoTests.Framework.Options.Internal;

internal sealed class ComponentOptions(object value) : IComponentOptions
{
    public T Get<T>()
    {
        if (value is not T result)
        {
            throw new Exception($"Invalid options type for '{typeof(T).FullName}'");
        }

        return result;
    }
}
