using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Models;
using AutoTests.Framework.Web.Binding;
using AutoTests.Framework.Web.Common.Extensions;

namespace AutoTests.Framework.Example.Web.Elements.Grids
{
    public abstract class GridBase<T> : BootstrapElement
        where T : Model, new()
    {
        protected GridBase(Application application) : base(application)
        {
        }

        public abstract int GetRowCount();

        public abstract Binder<T> Bind(int position);

        public IEnumerable<T> GetModels()
        {
            return Enumerable.Range(0, GetRowCount()).Select(x => Bind(x).GetValues());
        }

        public IEnumerable<T> GetModels(T expectedModel)
        {
            return Enumerable.Range(0, GetRowCount()).Select(x => Bind(x).GetValues(expectedModel));
        }
    }
}