using System.Threading.Tasks;

namespace AutoTests.Framework.Expressions;

public interface IExpressionService
{
    Task<T> ExecuteAsync<T>(string text);
}
