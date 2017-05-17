using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BoDi;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;

namespace AutoTests.Framework.Core.Transformations
{
    public class StepArgumentTransformationsDependencies : Dependencies
    {
        public StepArgumentTransformationsDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        private Assembly[] Assemblies => ObjectContainer.Resolve<Assembly[]>();

        private IBindingFactory BindingFactory => ObjectContainer.Resolve<IBindingFactory>();

        private IBindingRegistry BindingRegistry => ObjectContainer.Resolve<IBindingRegistry>();

        public override void Setup()
        {
            var defatulTransformations = GetStepArgumentTransformations().SelectMany(GetTransformationMethods);
            foreach (var methodInfo in defatulTransformations)
            {
                RegisterTransformations(methodInfo);
            }
        }

        public void RegisterTransformations(StepArgumentTransformations transformations)
        {
            foreach (var methodInfo in GetTransformationMethods(transformations.GetType()))
            {
                RegisterTransformations(methodInfo);
            }
        }

        private void RegisterTransformations(MethodInfo methodInfo)
        {
            var binding = BindingFactory.CreateStepArgumentTransformation("(.*)", new RuntimeBindingMethod(methodInfo));
            BindingRegistry.RegisterStepArgumentTransformationBinding(binding);
        }

        private IEnumerable<MethodInfo> GetTransformationMethods(Type type)
        {
            return type.GetMethods()
                .Where(x => x.GetCustomAttributes().OfType<StepArgumentTransformationAttribute>().Any());
        }

        private IEnumerable<Type> GetStepArgumentTransformations()
        {
            return Assemblies.SelectMany(x => x.GetTypes())
                .Where(x => !x.IsGenericType && !x.IsAbstract && x.IsSubclassOf(typeof(StepArgumentTransformations)));
        }
    }
}