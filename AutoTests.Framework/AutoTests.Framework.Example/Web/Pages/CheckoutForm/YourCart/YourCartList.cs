using AutoTests.Framework.Example.Web.Elements.Grids;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Example.Web.Pages.CheckoutForm.YourCart
{
    public class YourCartList : GridBase<YourCartModel>
    {
        private string ListItemLocator { get; set; }

        private GridLabel Title { get; set; }
        private GridLabel Description { get; set; }
        private GridLabel Price { get; set; }

        public YourCartList(Application application) : base(application)
        {
        }

        public override int GetRowCount()
        {
            return context.GetElementCount(ListItemLocator);
        }

        public override Binder<YourCartModel> Bind(int position)
        {
            return new Binder<YourCartModel>()
                .Bind(x => x.Title, Title, x => x.Position = position)
                .Bind(x => x.Description, Description, x => x.Position = position)
                .Bind(x => x.Price, Price, x => x.Position = position);
        }
    }
}