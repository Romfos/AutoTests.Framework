using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor;

    public interface IPreProcessor
    {
        Task<T> ExecuteAsync<T>(string text);
    }
