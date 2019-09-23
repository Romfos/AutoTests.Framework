using TechTalk.SpecFlow.Bindings;
using AutoTests.Framework.Core.Extensions;
using TechTalk.SpecFlow.Bindings.Reflection;
using System.Linq;
using TechTalk.SpecFlow;
using System.Reflection;
using System;

namespace AutoTests.Framework.Core.Specflow.Utils
{
    public class SpecflowBindingsUtils
    {
        private readonly IBindingRegistry bindingRegistry;
        private readonly IBindingFactory bindingFactory;

        public SpecflowBindingsUtils(IContainer container)
        {
            bindingRegistry = container.Resolve<IBindingRegistry>();
            bindingFactory = container.Resolve<IBindingFactory>();
        }

        public void RegisterStepArgumentTransformations(Type type)
        {
            foreach(var methodInfo in type.GetMethods())
            {
                var attribute = methodInfo.GetCustomAttributes().OfType<StepArgumentTransformationAttribute>().SingleOrDefault();
                if(attribute != null)
                {
                    var binding = bindingFactory.CreateStepArgumentTransformation(attribute.Regex, new RuntimeBindingMethod(methodInfo));
                    bindingRegistry.RegisterStepArgumentTransformationBinding(binding);
                }
            }
        }
    }
}
