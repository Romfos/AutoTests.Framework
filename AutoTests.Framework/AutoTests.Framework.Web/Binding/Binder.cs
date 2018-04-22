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
            Expression<Func<TModel, TProperty>> expression, 
            TPageObject pageObject,
            Action<TPageObject> precondition = null,
            Action<TPageObject> postcondition = null)
            where TPageObject : PageObject
        {
            binds.Add(CreateBind(expression, pageObject,
                GetRawAction(pageObject, precondition),
                GetRawAction(pageObject, postcondition)));
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
            Expression<Func<TModel, T>> expression, PageObject pageObject, Action precondition, Action postcondition)
        {
            return new Bind<TModel>(
                model => PropertyLink.Get(model, expression),
                pageObject,
                precondition,
                postcondition);
        }

        private Action GetRawAction<TPageObject>(TPageObject pageObject, Action<TPageObject> original)
            where TPageObject : PageObject
        {
            return original == null
                ? (Action) null
                : (() => original(pageObject));
        }
    }
}