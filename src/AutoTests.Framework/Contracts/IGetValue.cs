namespace AutoTests.Framework.Contracts;

public interface IGetValue<T>
{
    Task<T> GetValueAsync();
}
