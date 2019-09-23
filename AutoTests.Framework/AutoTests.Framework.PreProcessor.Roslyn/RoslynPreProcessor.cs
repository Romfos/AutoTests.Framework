using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor.Roslyn
{
    public class RoslynPreProcessor : IPreProcessor
    {
        private readonly object globals;
        private readonly ScriptOptions scriptOptions;

        public RoslynPreProcessor(object globals = null, ScriptOptions scriptOptions = null)
        {
            this.globals = globals;
            this.scriptOptions = scriptOptions ?? ScriptOptions.Default;
        }

        public async Task ExecuteAsync(string code)
        {
            await CSharpScript.EvaluateAsync(code, scriptOptions, globals);
        }

        public async Task<T> ExecuteAsync<T>(string code)
        {
            return await CSharpScript.EvaluateAsync<T>(code, scriptOptions, globals);
        }
    }
}