using AutoTests.Framework.Core;
using BoDi;

namespace AutoTests.Framework.PreProcessor
{
    public class PreProcessorServiceProvider : ServiceProvider
    {
        public PreProcessorServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Evaluator Evaluator => ObjectContainer.Resolve<Evaluator>();
    }
}