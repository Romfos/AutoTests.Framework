using AutoTests.Framework.Web.Common.Scripts;

namespace AutoTests.Framework.Web.Common.Elements
{
    public abstract class CommonElement : Element
    {
        protected CommonScriptLibrary CommonScriptLibrary { get; }
        protected CommonContext Context { get; }

        protected CommonElement(WebDependencies dependencies) : base(dependencies)
        {
            CommonScriptLibrary = dependencies.GetScriptLibrary<CommonScriptLibrary>();
            Context = dependencies.GetContext<CommonContext>();
        }
    }
}