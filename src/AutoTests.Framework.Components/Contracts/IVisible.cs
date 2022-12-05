using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Contracts;

public interface IVisible
{
    Task<bool> IsVisibleAsync();
}
