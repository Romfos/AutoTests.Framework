namespace AutoTests.Framework.Contracts;

public interface ISetValue<T>
{
    Task SetValueAsync(T value);
}
