using System;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using BoDi;

namespace AutoTests.Framework.Web.Services
{
    public class ConfiguratorsDependencies : Dependencies
    {
        public ConfiguratorsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        public PageObjectService PageObjectService 
            => ObjectContainer.Resolve<PageObjectService>();

        public PageObjectConfiguratorService PageObjectConfiguratorService => ObjectContainer.Resolve<PageObjectConfiguratorService>();

        public ElementFactory ElementFactory => ObjectContainer.Resolve<ElementFactory>();

        public LocatorAttributeService LocatorAttributeService
            => ObjectContainer.Resolve<LocatorAttributeService>();

        public LocatorsJsonService LocatorsJsonService
            => ObjectContainer.Resolve<LocatorsJsonService>();

        public ElementLocatorService ElementLocatorService
            => ObjectContainer.Resolve<ElementLocatorService>();

        public Element CreateElement(Type elementType)
        {
            var arguments = elementType.GetConstructors()
                .Single()
                .GetParameters()
                .Select(x => ObjectContainer.Resolve(x.ParameterType))
                .ToArray();

            return (Element) Activator.CreateInstance(elementType, arguments);
        }
    }
}