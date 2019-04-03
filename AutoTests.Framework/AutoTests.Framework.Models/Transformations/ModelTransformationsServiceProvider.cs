using System;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Specflow;
using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Framework.Models.Transformations
{
    public class ModelTransformationsServiceProvider : ServiceProvider
    {
        public ModelTransformationsServiceProvider(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public PreProcessorServiceProvider PreProcessorServiceProvider => 
            ObjectContainer.Resolve<PreProcessorServiceProvider>();

        public ModelStepArgumentTransformationsService ModelStepArgumentTransformationsService =>
            ObjectContainer.Resolve<ModelStepArgumentTransformationsService>();

        internal AssemblyPool AssemblyPool => ObjectContainer.Resolve<AssemblyPool>();

        internal StepArgumentTransformationsService StepArgumentTransformationsService =>
            ObjectContainer.Resolve<StepArgumentTransformationsService>();

        internal object GetModelStepArgumentTransformations(Type model)
        {
            var type = typeof(ModelStepArgumentTransformations<>).MakeGenericType(model);
            return ObjectContainer.Resolve(type);
        }
    }
}