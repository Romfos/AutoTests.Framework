using AutoTests.Framework.Data;

namespace AutoTests.Framework.Expressions;

public class ExpressionEnvironment
{
    public dynamic Data { get; }

    public ExpressionEnvironment(DataService dataService)
    {
        Data = dataService.Data;
    }
}
