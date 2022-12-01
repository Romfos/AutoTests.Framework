using AutoTests.Framework.Expressions;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models;

[Binding]
public sealed class ModelsSpecflowHooks
{
    private readonly IExpressionService expressionService;

    public ModelsSpecflowHooks(IExpressionService expressionService)
    {
        this.expressionService = expressionService;
    }

    [StepArgumentTransformation]
    public IModel TransformExpression(Table table)
    {
        return new Model(expressionService, table);
    }
}
