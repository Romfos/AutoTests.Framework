using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoTests.Framework.Models;

namespace AutoTests.Framework.Web.Binding
{
    public class Binder<TModel>
        where TModel : Model
    {
        private readonly List<Bind<TModel>> binds = new List<Bind<TModel>>();

        public Binder<TModel> Bind<T>(Expression<Func<TModel, T>> expression, PageObject pageObject)
        {
            binds.Add(new Bind<TModel>(model => PropertyLink.Get(model, expression), pageObject));
            return this;
        }

        public object[] Trigger<THandler>(TModel model)
            where THandler : Handler
        {
            return binds
                .Where(x => x.Check<THandler>(model))
                .Select(x => x.Trigger<THandler>(model))
                .ToArray();
        }
    }
}