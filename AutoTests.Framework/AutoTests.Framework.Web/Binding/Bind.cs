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
        private readonly Action precondition;
        private readonly Action postcondition;

        public Bind(Func<TModel, PropertyLink> selector, 
            PageObject pageObject, Action precondition, Action postcondition)
        {
            this.selector = selector;
            this.pageObject = pageObject;
            this.precondition = precondition;
            this.postcondition = postcondition;
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
            return TriggerHandler(handler, handlerArgs);
        }

        private object TriggerHandler(Handler handler, HandlerArgs handlerArgs)
        {
            precondition?.Invoke();
            try
            {
                return handler.Trigger(handlerArgs);
            }
            finally
            {
                postcondition?.Invoke();
            }
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