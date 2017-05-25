using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.Core.Transformations;
using AutoTests.Framework.Models;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.Web;
using AutoTests.PreProcessor;
using AutoTests.Web;
using BoDi;

namespace AutoTests
{
    public class Application : Dependencies
    {
        public Application(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public StepsDependencies Steps => ObjectContainer.Resolve<StepsDependencies>();

        public StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        public PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        public WebDependencies Web => ObjectContainer.Resolve<WebDependencies>();

        public ModelsDependencies Models => ObjectContainer.Resolve<ModelsDependencies>();
        
        private StepArgumentTransformationsDependencies StepArgumentTransformations
            => ObjectContainer.Resolve<StepArgumentTransformationsDependencies>();

        public override void Setup()
        {
            ObjectContainer.RegisterInstanceAs(new[]
            {
                typeof(Application).Assembly,

                typeof(Dependencies).Assembly,
                typeof(PreProcessorDependencies).Assembly,
                typeof(WebDependencies).Assembly,
                typeof(ModelsDependencies).Assembly,
            });

            ObjectContainer.RegisterTypeAs<IWebDriverFactory>(typeof(ChromeDriverFactory));
            ObjectContainer.RegisterTypeAs<Options>(typeof(ExampleOptions));

            Steps.Setup();
            Stores.Setup();
            PreProcessor.Setup();
            Models.Setup();
            StepArgumentTransformations.Setup();
            Web.Setup();
        }
    }
}