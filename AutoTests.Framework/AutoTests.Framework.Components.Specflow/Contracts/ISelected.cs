using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts;

public interface ISelected
{
    Task<bool> IsSelectedAsync();
}
