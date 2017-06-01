using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.Models;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.TestData;
using AutoTests.Framework.Web;
using BoDi;

namespace AutoTests.Framework.Tests
{
    public class Application : Dependencies
    {
        public Application(ObjectContainer objectContainer) : base(objectContainer)
        {
        }
        
        public StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        public ModelsDependencies Models => ObjectContainer.Resolve<ModelsDependencies>();

        public WebDependencies Web => ObjectContainer.Resolve<WebDependencies>();

        public PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        public StepsDependencies Steps => ObjectContainer.Resolve<StepsDependencies>();
        
        public TestDataDependencies TestData => ObjectContainer.Resolve<TestDataDependencies>();

        protected override void RegisterCustomTypes()
        {
            Steps.Register();
            Models.Register();
            PreProcessor.Register();
            Stores.Register();
            Web.Register();
            TestData.Register();
        }

        protected override void ConfigureDependencies()
        {
            Steps.Configure();
            Models.Configure();
            PreProcessor.Configure();
            Stores.Configure();
            Web.Configure();
            TestData.Configure();
        }
    }
}