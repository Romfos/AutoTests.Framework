using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Framework.Tests
{
    public class Application
    {
        private readonly IObjectContainer objectContainer;

        public Application(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public Evaluator Evaluator => objectContainer.Resolve<Evaluator>();
    }
}