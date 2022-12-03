using AutoTests.Framework.Expressions;
using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Contracts;

public interface ISetValue
{
    Task SetValueAsync(ArgumentExpression expression);
}
