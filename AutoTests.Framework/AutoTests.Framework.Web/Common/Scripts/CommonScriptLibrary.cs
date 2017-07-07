namespace AutoTests.Framework.Web.Common.Scripts
{
    public class CommonScriptLibrary : ScriptLibrary
    {
        protected CommonContext Context { get; }

        public CommonScriptLibrary(WebDependencies dependencies) : base(dependencies)
        {
            Context = dependencies.GetContext<CommonContext>();
        }

        public string GetValue(string locator)
        {
            return (string) Context.Execute(GetScriptByName("getValue.js"), locator);
        }

        public void SetValue(string locator, string value)
        {
            Context.Execute(GetScriptByName("setValue.js"), locator, value);
        }
    }
}