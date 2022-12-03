using System.Threading.Tasks;

namespace AutoTests.Framework.Expressions;

public sealed class ArgumentExpression
{
    private readonly IExpressionService expressionService;
    private readonly string text;

    public ArgumentExpression(IExpressionService expressionService, string text)
    {
        this.expressionService = expressionService;
        this.text = text;
    }

    public async Task<T> ExecuteAsync<T>()
    {
        return await expressionService.ExecuteAsync<T>(text);
    }
}
