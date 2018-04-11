using AutoTests.Framework.Tests.Web.Elements;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Tests.Web.Pages.PreconditionTest
{
    public class PreconditionTestPage : DemoPage
    {
        public ElementWithPrecondition Element { get; set; }

        public PreconditionTestPage(Application application) : base(application)
        {
        }

        public Binder<PreconditionTestModel> BindPreconditionTestModel(int position)
        {
            return new Binder<PreconditionTestModel>()
                .Bind(x => x.Value, Element, x => x.Position = position);
        }
    }
}