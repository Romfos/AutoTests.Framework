using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor
{
    public interface IPreProcessor
    {
        Task ExecuteAsync(string code);
        Task<T> ExecuteAsync<T>(string code);
    }
}
