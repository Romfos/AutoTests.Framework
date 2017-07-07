namespace AutoTests.Framework.Web.Common.Elements
{
    public abstract class CommonElement : Element
    {
        protected CommonContext Context { get; }

        protected CommonElement(WebDependencies dependencies)
        {
            Context = dependencies.GetContext<CommonContext>();
        }
    }
}