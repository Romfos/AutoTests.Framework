using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Transformations;
using AutoTests.Framework.Models.Comparator;
using AutoTests.Framework.Models.Transformations;
using AutoTests.Framework.PreProcessor;
using BoDi;

namespace AutoTests.Framework.Models
{
    public class ModelsDependencies : Dependencies
    {
        public ModelsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        internal PreProcessorDependencies PreProcessor => ObjectContainer.Resolve<PreProcessorDependencies>();

        public ModelTransformations ModelTransformations => ObjectContainer.Resolve<ModelTransformations>();

        public ModelComparator Comparator => ObjectContainer.Resolve<ModelComparator>();

        private StepArgumentTransformationsDependencies StepArgumentTransformations
            => ObjectContainer.Resolve<StepArgumentTransformationsDependencies>();

        private IEnumerable<Type> GetModelTypes()
        {
            return Core.Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Model)));
        }

        private void RegisterSpecflowModelTransformations(Type modelType)
        {
            var type = typeof(SpecflowModelTransformations<>).MakeGenericType(modelType);
            var instance = (StepArgumentTransformations) ObjectContainer.Resolve(type);
            StepArgumentTransformations.RegisterTransformations(instance);
        }

        protected override void CustomRegister()
        {
            PreProcessor.Register();
        }

        protected override void CustomConfigure()
        {
            PreProcessor.Configure();

            foreach (var modelType in GetModelTypes())
            {
                RegisterSpecflowModelTransformations(modelType);
            }
        }
    }
}