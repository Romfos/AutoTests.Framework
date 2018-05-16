using AutoTests.Framework.Web.Attributes;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Example.Web.Elements.Grids
{
    public class GridLabel : BootstrapElement
    {
        [FromLocator]
        public string Locator { get; set; }

        public int Position { get; set; }

        public GridLabel(Application application) : base(application)
        {
        }

        [GetValue]
        public string GetValue()
        {
            return context.GetText(string.Format(Locator, Position + 1));
        }
    }
}