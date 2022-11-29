using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor.Roslyn;

public class RoslynPreProcessor : IPreProcessor
{
    private readonly object? globals;
    private readonly ScriptOptions? scriptOptions;

    public RoslynPreProcessor(object? globals = null, ScriptOptions? scriptOptions = null)
    {
        this.globals = globals;
        this.scriptOptions = scriptOptions ?? ScriptOptions.Default;
    }

    public async Task<T> ExecuteAsync<T>(string text)
    {
        var source = text.Trim();
        if (source.Length > 1 && source[0] == '@')
        {
            var code = source.Substring(1);
            var result = await CSharpScript.EvaluateAsync(code, scriptOptions, globals);
            return (T)Convert.ChangeType(result, typeof(T));
        }
        else
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }
    }
}