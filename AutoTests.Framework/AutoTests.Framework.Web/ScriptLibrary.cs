using AutoTests.Framework.Core.Utils;

namespace AutoTests.Framework.Web
{
    public abstract class ScriptLibrary
    {
        private readonly ResourceUtils resources;

        protected ScriptLibrary(WebDependencies dependencies)
        {
            resources = dependencies.Utils.Resources;
        }

        protected string GetScriptByName(string scriptName)
        {
            return resources.GetTextResource(this, scriptName);
        }
    }
}