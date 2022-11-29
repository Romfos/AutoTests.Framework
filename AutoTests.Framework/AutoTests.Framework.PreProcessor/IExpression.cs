using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor;

public interface IExpression
{
    Task<T> ExecuteAsync<T>();
}
