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

        public Binder<TModel> Bind<TProperty, TPageObject>(
            Expression<Func<TModel, TProperty>> expression, TPageObject pageObject, params Action<TPageObject>[] preconditions)
            where TPageObject : PageObject
        {
            binds.Add(CreateBind(expression, pageObject, GetPreconditions(pageObject, preconditions)));
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

        private Bind<TModel> CreateBind<T>(
            Expression<Func<TModel, T>> expression, PageObject pageObject, List<Action> preconditions)
        {
            return new Bind<TModel>(model => PropertyLink.Get(model, expression), pageObject, preconditions);
        }

        private List<Action> GetPreconditions<T>(T pageObject, Action<T>[] preconditions)
            where T: PageObject
        {
            return preconditions.Select(action => new Action(() => action(pageObject))).ToList();
        }
    }
}