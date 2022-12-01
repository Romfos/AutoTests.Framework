using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoTests.Framework.Models;

public interface IModel
{
    Task<T> GetValueAsync<T>();

    IAsyncEnumerable<T> GetValuesAsync<T>();
}
