namespace AutoTests.Framework.Web.Common.Scripts
{
    public class CommonScriptLibrary : ScriptLibrary
    {
        private readonly WebDependencies dependencies;

        protected CommonContext Context => dependencies.GetContext<CommonContext>();

        public CommonScriptLibrary(WebDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        protected T Execute<T>(string scriptName, params object[] args)
        {
            var script = dependencies.Utils.Resources.GetTextResource(this, scriptName);
            return (T) Context.Execute(script, args);
        }

        protected void Execute(string scriptName, params object[] args)
        {
            var script = dependencies.Utils.Resources.GetTextResource(this, scriptName);
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