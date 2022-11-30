using AutoTests.Framework.PreProcessor;
using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts;

public interface IEqualTo
{
    Task<bool> EqualToAsync(IExpression expression);
}
