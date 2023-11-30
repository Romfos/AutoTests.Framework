using AutoTests.Framework.Expressions;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models;

[Binding]
public sealed class ModelsSpecflowHooks(IExpressionService expressionService)
{
    [StepArgumentTransformation]
    public IModel TransformModel(Table table)
    {
        return new Model(expressionService, table);
    }

    [StepArgumentTransformation]
    public Dictionary<ArgumentExpression, ArgumentExpression> TransformArgumentDictionary(Table table)
    {
        return table.Rows.ToDictionary(
            x => new ArgumentExpression(expressionService, x["Name"]),
            x => new ArgumentExpression(expressionService, x["Value"]));
    }

    [StepArgumentTransformation]
    public IEnumerable<ArgumentExpression> TransformArgumentEnumerable(Table table)
    {
        return table.Rows.Select(x => new ArgumentExpression(expressionService, x["Name"]));
    }
}
