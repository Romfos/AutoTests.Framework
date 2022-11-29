using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using System.Linq;
using TechTalk.SpecFlow;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace AutoTests.Framework.Core.Specflow.Utils;

    public class SpecflowBindingsUtils
    {
        private readonly IBindingRegistry bindingRegistry;
        private readonly IBindingFactory bindingFactory;

        public SpecflowBindingsUtils(IBindingRegistry bindingRegistry, IBindingFactory bindingFactory)
        {
            this.bindingRegistry = bindingRegistry;
            this.bindingFactory = bindingFactory;
        }

        public void RegisterBindings(Type type)
        {
            RegsiterStepTransformations(type);
            RegisterStepBindings<GivenAttribute>(type, StepDefinitionType.Given);
            RegisterStepBindings<WhenAttribute>(type, StepDefinitionType.When);
            RegisterStepBindings<ThenAttribute>(type, StepDefinitionType.Then);
        }

        private void RegisterStepBindings<T>(Type type, StepDefinitionType stepDefinitionType) 
            where T: StepDefinitionBaseAttribute
        {
            foreach (var (method, attribute) in GetTypeMethods<T>(type))
            {
                var binding = bindingFactory.CreateStepBinding(
                    stepDefinitionType, attribute.Regex, new RuntimeBindingMethod(method), null);
                bindingRegistry.RegisterStepDefinitionBinding(binding);
            }
        }

        private void RegsiterStepTransformations(Type type)
        {
            foreach (var (method, attribute) in GetTypeMethods<StepArgumentTransformationAttribute>(type))
            {
                var binding = bindingFactory.CreateStepArgumentTransformation(
                    attribute.Regex, 
                    new RuntimeBindingMethod(method));
                bindingRegistry.RegisterStepArgumentTransformationBinding(binding);
            }
        }

        private IEnumerable<(MethodInfo method, T attribute)> GetTypeMethods<T>(Type type)
            where T: Attribute
        {
            return type.GetMethods()
                .Select(x => (method: x, attribute: x.GetCustomAttributes().OfType<T>().SingleOrDefault()))
                .Where(x => x.attribute != null)!;
        }
    }
