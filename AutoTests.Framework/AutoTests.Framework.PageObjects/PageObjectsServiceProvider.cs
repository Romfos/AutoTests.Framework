using System;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using AutoTests.Framework.PageObjects.Services;
using BoDi;

namespace AutoTests.Framework.PageObjects
{
    public class PageObjectsServiceProvider : ServiceProvider
    {
        public PageObjectsServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal UtilsServiceProvider Utils => ObjectContainer.Resolve<UtilsServiceProvider>();

        internal PageObjectLoader PageObjectLoader =>
            ObjectContainer.Resolve<PageObjectLoader>();

        internal PageObjectElementsLoader PageObjectElementsLoader =>
            ObjectContainer.Resolve<PageObjectElementsLoader>();

        internal PageObjectLocatorsLoader PageObjectLocatorsLoader =>
            ObjectContainer.Resolve<PageObjectLocatorsLoader>();

        public T GetPage<T>()
            where T : Page
        {
            return ObjectContainer.Resolve<T>();
        }

        internal Element CreateElement(Type type)
        {
            var constructorInfo = type.GetConstructors().Single();
            var arguments = constructorInfo.GetParameters()
                .Select(x => ObjectContainer.Resolve(x.ParameterType)).ToArray();
            var element = (Element) constructorInfo.Invoke(arguments);
            return element;
        }
    }
}