using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts;

public interface IVisible
{
    Task<bool> IsVisibleAsync();
}
