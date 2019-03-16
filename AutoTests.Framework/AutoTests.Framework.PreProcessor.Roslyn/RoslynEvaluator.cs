using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace AutoTests.Framework.PreProcessor.Roslyn
{
    public class RoslynEvaluator : Evaluator
    {
        private ScriptState scriptState;

        public override async Task<T> Evaluate<T>(string code)
        {
            var value = await Evaluate(code);
            var result = (T)Convert.ChangeType(value, typeof(T));
            return result;
        }

        private async Task<object> Evaluate(string code)
        {
            var roslynCode = code.Trim();
            if (roslynCode.Length > 1 && roslynCode[0] == '@')
            {
                roslynCode = roslynCode.Substring(1);
                return await EvaluateRoslynScript(roslynCode);
            }
            return code;
        }

        private async Task<object> EvaluateRoslynScript(string code)
        {
            var newScriptState = await EvaluateScriptState(code);
            scriptState = newScriptState;
            return newScriptState.ReturnValue;
        }

        private async Task<ScriptState> EvaluateScriptState(string code)
        {
            return scriptState == null
                ? await CreateScriptState(code)
                : await Continue(code);
        }

        protected virtual async Task<ScriptState> CreateScriptState(string code)
        {
            return await CSharpScript.RunAsync(code);
        }

        protected virtual async Task<ScriptState> Continue(string code)
        {
            return await scriptState.ContinueWithAsync(code);
        }
    }
}