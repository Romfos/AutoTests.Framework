using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.Models.Transformations
{
    public class ModelStepArgumentTransformationsService
    {
        private readonly ModelTransformationsServiceProvider serviceProvider;

        public ModelStepArgumentTransformationsService(ModelTransformationsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void RegisterStepArgumentTransformations()
        {
            foreach (var modelType in GetModelTypes())
            {
                RegisterModelStepArgumentTransformations(modelType);
            }
        }

        private void RegisterModelStepArgumentTransformations(Type modelType)
        {
            var transformations = serviceProvider.GetModelStepArgumentTransformations(modelType);
            serviceProvider.StepArgumentTransformationsService.RegisterStepArgumentTransformations(transformations);
        }

        private IEnumerable<Type> GetModelTypes()
        {
            return serviceProvider.AssemblyPool.Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(Model)));
        }
    }
}