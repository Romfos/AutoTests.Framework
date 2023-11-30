namespace AutoTests.Framework.Expressions;

public sealed class ArgumentExpression(IExpressionService expressionService, string text)
{
    public async Task<T> ExecuteAsync<T>()
    {
        return await expressionService.ExecuteAsync<T>(text);
    }
}
