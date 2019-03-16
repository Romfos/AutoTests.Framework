using AutoTests.Framework.Core;
using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Framework.Tests
{
    public class Application : ServiceProvider
    {
        public Application(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Evaluator Evaluator => ObjectContainer.Resolve<Evaluator>();

        public PageObjectsServiceProvider PageObjects => ObjectContainer.Resolve<PageObjectsServiceProvider>();
    }
}