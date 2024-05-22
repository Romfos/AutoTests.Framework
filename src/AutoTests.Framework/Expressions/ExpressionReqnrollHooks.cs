using Reqnroll;
using Reqnroll.BoDi;

namespace AutoTests.Framework.Expressions;

[Binding]
public sealed class ExpressionReqnrollHooks(IExpressionService expressionService)
{
    [StepArgumentTransformation]
    public ArgumentExpression TransformExpression(string text)
    {
        return new ArgumentExpression(expressionService, text);
    }

    [BeforeTestRun(Order = int.MinValue)]
    public static void BeforeTestRun(ObjectContainer objectContainer)
    {
        objectContainer.RegisterTypeAs<RoslynCSharpExpressionService, IExpressionService>();
    }
}
