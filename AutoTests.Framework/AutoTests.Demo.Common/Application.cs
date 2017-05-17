using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Stores;
using AutoTests.Framework.Core.Transformations;
using AutoTests.Framework.Models;
using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Demo.Common
{
    public class Application : Dependencies
    {
        public Application(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public StoresDependencies Stores => ObjectContainer.Resolve<StoresDependencies>();

        public ModelsDependencies Models => ObjectContainer.Resolve<ModelsDependencies>();

        public PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        public StepArgumentTransformationsDependencies StepArgumentTransformations
            => ObjectContainer.Resolve<StepArgumentTransformationsDependencies>();

        public override void Setup()
        {
            ObjectContainer.RegisterInstanceAs(new[]
            {
                typeof(Dependencies).Assembly,
                typeof(ModelsDependencies).Assembly,
                typeof(Application).Assembly,
                typeof(PreProcessorDependencies).Assembly,
            });
            
            Models.Setup();
            PreProcessor.Setup();
            Stores.Setup();
            StepArgumentTransformations.Setup();
        }
    }
}