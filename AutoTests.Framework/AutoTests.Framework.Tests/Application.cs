using AutoTests.Framework.Core;
using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PageObjects.Provider;
using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Framework.Tests
{
    public class Application : ServiceProvider
    {
        public Application(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public PreProcessorServiceProvider PreProcessor => 
            ObjectContainer.Resolve<PreProcessorServiceProvider>();

        public PageObjectsServiceProvider PageObjects => 
            ObjectContainer.Resolve<PageObjectsServiceProvider>();

        public PageObjectProviderServiceProvider PageObjectProvider =>
            ObjectContainer.Resolve<PageObjectProviderServiceProvider>();
    }
}