using BoDi;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Expressions;

[Binding]
public sealed class ExpressionSpecflowHooks
{
    private readonly IExpressionService expressionService;

    public ExpressionSpecflowHooks(IExpressionService expressionService)
    {
        this.expressionService = expressionService;
    }

    [StepArgumentTransformation]
    public ArgumentExpression TransformExpression(string text)
    {
        return new ArgumentExpression(expressionService, text);
    }

    [BeforeScenario(Order = int.MinValue)]
    public static void BeforeScenario(IObjectContainer objectContainer)
    {
        objectContainer.RegisterTypeAs<RoslynCSharpExpressionService, IExpressionService>();
    }
}
