using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace AutoTests.Framework.Expressions;

internal sealed class RoslynCSharpExpressionService(ExpressionEnvironment expressionEnvironment) : IExpressionService
{
    private readonly ScriptOptions scriptOptions = ScriptOptions.Default.AddReferences("Microsoft.CSharp");

    public async Task<T> ExecuteAsync<T>(string text)
    {
        if (text.AsSpan().TrimStart().StartsWith("@".AsSpan()))
        {
            var code = text.AsSpan().Trim().Slice(1).ToString();
            var result = await CSharpScript.EvaluateAsync(code, scriptOptions, expressionEnvironment);
            return (T)Convert.ChangeType(result, typeof(T));
        }
        else
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }
    }
}
