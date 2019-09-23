using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor
{
    public interface IPreProcessor
    {
        Task ExecuteAsync(string source);
        Task<T> ExecuteAsync<T>(string source);
    }
}
