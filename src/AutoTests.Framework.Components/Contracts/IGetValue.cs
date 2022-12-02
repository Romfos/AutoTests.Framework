using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Contracts;

public interface IGetValue
{
    Task<object?> GetValueAsync();
}
