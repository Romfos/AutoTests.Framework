using System.Threading.Tasks;

namespace AutoTests.Framework.Expressions;

internal sealed class RoslynCSharpExpression : IExpression
{
    private readonly IExpressionService expressionService;
    private readonly string text;

    public RoslynCSharpExpression(IExpressionService expressionService, string text)
    {
        this.expressionService = expressionService;
        this.text = text;
    }

    public async Task<T> ExecuteAsync<T>()
    {
        return await expressionService.ExecuteAsync<T>(text);
    }
}
