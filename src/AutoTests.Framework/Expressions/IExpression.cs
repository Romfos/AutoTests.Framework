using System.Threading.Tasks;

namespace AutoTests.Framework.Expressions;

public interface IExpression
{
    Task<T> ExecuteAsync<T>();
}
