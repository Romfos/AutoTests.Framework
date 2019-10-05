using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts
{
    public interface IEnabled
    {
        Task<bool> IsEnabledAsync();
    }
}
