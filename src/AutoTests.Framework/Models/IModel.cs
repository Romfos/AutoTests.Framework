namespace AutoTests.Framework.Models;

public interface IModel
{
    Task<T> GetValueAsync<T>();

    IAsyncEnumerable<T> GetValuesAsync<T>();
}
