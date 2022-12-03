using AutoTests.Framework.Data;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.Expressions;

internal sealed class RoslynCSharpExpressionService : IExpressionService
{
    private readonly RoslynGlobals globals;
    private readonly ScriptOptions scriptOptions;

    public RoslynCSharpExpressionService(DataService dataService)
    {
        globals = new RoslynGlobals(dataService.Data);
        scriptOptions = ScriptOptions.Default.AddReferences("Microsoft.CSharp");
    }

    public async Task<T> ExecuteAsync<T>(string text)
    {
        if (text.AsSpan().TrimStart().StartsWith("@".AsSpan()))
        {
            var code = text.AsSpan().Trim().Slice(1).ToString();
            var result = await CSharpScript.EvaluateAsync(code, scriptOptions, globals);
            return (T)Convert.ChangeType(result, typeof(T));
        }
        else
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }
    }
}
