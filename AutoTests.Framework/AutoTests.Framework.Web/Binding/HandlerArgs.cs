using System.Reflection;
using AutoTests.Framework.Models;

namespace AutoTests.Framework.Web.Binding
{
    public class HandlerArgs
    {
        private readonly MethodInfo methodInfo;
        private readonly PageObject pageObject;

        public PropertyLink PropertyLink { get; }

        public HandlerArgs(PageObject pageObject, MethodInfo methodInfo, PropertyLink propertyLink)
        {
            this.pageObject = pageObject;
            this.methodInfo = methodInfo;
            PropertyLink = propertyLink;
        }

        public object Invoke(params object[] args)
        {
            return methodInfo.Invoke(pageObject, args);
        }
    }
}