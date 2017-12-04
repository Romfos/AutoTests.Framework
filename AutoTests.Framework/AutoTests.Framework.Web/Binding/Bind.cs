using System;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Models;

namespace AutoTests.Framework.Web.Binding
{
    internal class Bind<TModel>
        where TModel : Model
    {
        private readonly Func<TModel, PropertyLink> selector;
        private readonly PageObject pageObject;

        public Bind(Func<TModel, PropertyLink> selector, PageObject pageObject)
        {
            this.selector = selector;
            this.pageObject = pageObject;
        }

        public bool Check<THandler>(TModel model)
            where THandler : Handler
        {
            var method = GetHandlerMethod<THandler>();
            var propertyLink = selector(model);
            return propertyLink.Enabled && method != null;
        }

        public object Trigger<THandler>(TModel model)
            where THandler : Handler
        {
            var method = GetHandlerMethod<THandler>();
            var handler = method.GetCustomAttributes<THandler>().Single();
            var propertyLink = selector(model);
            var handlerArgs = new HandlerArgs(pageObject, method, propertyLink);
            return handler.Trigger(handlerArgs);
        }

        private MethodInfo GetHandlerMethod<THandler>()
            where THandler : Handler
        {
            return pageObject.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .SingleOrDefault(x => x.GetCustomAttributes<THandler>().SingleOrDefault() != null);
        }
    }
}