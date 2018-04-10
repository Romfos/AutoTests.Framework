using System;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Utils;
using BoDi;

namespace AutoTests.Framework.Web.Configurators
{
    public class ConfiguratorsDependencies : Dependencies
    {
        public ConfiguratorsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal UtilsDependencies Utils => ObjectContainer.Resolve<UtilsDependencies>();

        public PageObjectPropertiesProvider PageObjectPropertiesProvider 
            => ObjectContainer.Resolve<PageObjectPropertiesProvider>();

        public PageObjectConfigurator PageObjectConfigurator => ObjectContainer.Resolve<PageObjectConfigurator>();

        public ElementFactory ElementFactory => ObjectContainer.Resolve<ElementFactory>();

        public LocatorAttributeConfigurator LocatorAttributeConfigurator
            => ObjectContainer.Resolve<LocatorAttributeConfigurator>();

        public LocatorsConfigurator LocatorsConfigurator
            => ObjectContainer.Resolve<LocatorsConfigurator>();

        public ElementLocatorConfigurator ElementLocatorConfigurator
            => ObjectContainer.Resolve<ElementLocatorConfigurator>();

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