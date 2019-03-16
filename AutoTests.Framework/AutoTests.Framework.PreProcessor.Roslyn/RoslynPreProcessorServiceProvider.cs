using AutoTests.Framework.Core;
using BoDi;

namespace AutoTests.Framework.PreProcessor.Roslyn
{
    public class RoslynPreProcessorServiceProvider : ServiceProvider
    {
        public RoslynPreProcessorServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal PreProcessorServiceProvider PreProcessor => ObjectContainer.Resolve<PreProcessorServiceProvider>();
    }
}