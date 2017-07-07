using AutoTests.Framework.Core.Utils;

namespace AutoTests.Framework.Web.Common.Scripts
{
    public class JavaScripts : ScriptLibrary
    {
        protected CommonContext Context { get; }
        protected ResourceUtils Resources { get; }

        public JavaScripts(WebDependencies dependencies)
        {
            Context = dependencies.GetContext<CommonContext>();
            Resources = dependencies.Utils.Resources;
        }

        protected T Execute<T>(string scriptName, params object[] args)
        {
            var script = Resources.GetTextResource(this, scriptName);
            return (T) Context.Execute(script, args);
        }

        protected void Execute(string scriptName, params object[] args)
        {
            var script = Resources.GetTextResource(this, scriptName);
            Context.Execute(script, args);
        }

        public string GetValue(string locator)
        {
            return Execute<string>("getValue.js", locator);
        }

        public void SetValue(string locator, string value)
        {
            Execute("setValue.js", locator, value);
        }
    }
}