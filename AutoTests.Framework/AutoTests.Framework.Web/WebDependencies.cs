using System;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using BoDi;

namespace AutoTests.Framework.Web
{
    public class WebDependencies : Dependencies
    {
        public WebDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal ResourceUtils Resources => ObjectContainer.Resolve<ResourceUtils>();

        public T GetPage<T>()
            where T : Page
        {
            return ObjectContainer.Resolve<T>();
        }

        public T GetContext<T>()
            where T : Context
        {
            return ObjectContainer.Resolve<T>();
        }

        public Control CreateControl(Type controlType)
        {
            var arguments = controlType.GetConstructors()
                .Single()
                .GetParameters()
                .Select(x => ObjectContainer.Resolve(x.ParameterType))
                .ToArray();

            return (Control) Activator.CreateInstance(controlType, arguments);
        }

        public IWebDriverFactory WebDriverFactory => ObjectContainer.Resolve<IWebDriverFactory>();

        public override void Setup()
        {
        }
    }
}