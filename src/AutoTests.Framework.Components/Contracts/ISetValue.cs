using AutoTests.Framework.Expressions;

namespace AutoTests.Framework.Components.Contracts;

public interface ISetValue
{
    Task SetValueAsync(ArgumentExpression expression);
}
