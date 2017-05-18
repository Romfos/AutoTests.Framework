﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Transformations;
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

        internal Compiler Compiler => ObjectContainer.Resolve<Compiler>();

        public ModelTransformations ModelTransformations => ObjectContainer.Resolve<ModelTransformations>();

        private StepArgumentTransformationsDependencies StepArgumentTransformations
            => ObjectContainer.Resolve<StepArgumentTransformationsDependencies>();

        private IEnumerable<Type> GetModelTypes()
        {
            return ObjectContainer.Resolve<Assembly[]>()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Model)));
        }

        private void RegisterSpecflowModelTransformations(Type modelType)
        {
            var type = typeof(SpecflowModelTransformations<>).MakeGenericType(modelType);
            var instance = (StepArgumentTransformations) ObjectContainer.Resolve(type);
            StepArgumentTransformations.RegisterTransformations(instance);
        }

        public override void Setup()
        {
            foreach (var modelType in GetModelTypes())
            {
                RegisterSpecflowModelTransformations(modelType);
            }
        }
    }
}