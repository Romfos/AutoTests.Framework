using AutoTests.Framework.Data;

namespace AutoTests.Framework.Expressions;

public class ExpressionEnvironment(DataService dataService)
{
    public dynamic Data { get; } = dataService.Data;
}
