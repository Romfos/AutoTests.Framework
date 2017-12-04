using System;

namespace AutoTests.Framework.Web.Binding
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class Handler : Attribute
    {
        public abstract object Trigger(HandlerArgs args);
    }
}