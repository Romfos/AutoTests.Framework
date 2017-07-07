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

        internal UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        public IWebDriverFactory WebDriverFactory => ObjectContainer.Resolve<IWebDriverFactory>();

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

        internal Element CreateElement(Type controlType)
        {
            var arguments = controlType.GetConstructors()
                .Single()
                .GetParameters()
                .Select(x => ObjectContainer.Resolve(x.ParameterType))
                .ToArray();

            return (Element) Activator.CreateInstance(controlType, arguments);
        }

        protected override void RegisterCustomTypes()
        {
            Utils.Register();
        }

        protected override void ConfigureDependencies()
        {
            Utils.Configure();
        }
    }
}