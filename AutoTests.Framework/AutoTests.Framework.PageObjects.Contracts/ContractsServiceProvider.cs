using AutoTests.Framework.Core;
using AutoTests.Framework.PageObjects.Provider;
using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Framework.PageObjects.Contracts
{
    public class ContractsServiceProvider : ServiceProvider
    {
        public ContractsServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal PreProcessorServiceProvider PreProcessor =>
            ObjectContainer.Resolve<PreProcessorServiceProvider>();

        internal PageObjectProviderServiceProvider PageObjectProvider =>
            ObjectContainer.Resolve<PageObjectProviderServiceProvider>();
    }
}