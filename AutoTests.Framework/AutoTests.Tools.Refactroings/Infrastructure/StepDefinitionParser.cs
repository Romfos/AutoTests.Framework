using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoTests.Tools.Refactroings.Entities;
using TechTalk.SpecFlow;

namespace AutoTests.Tools.Refactroings.Infrastructure
{
    public class StepDefinitionParser
    {
        public IEnumerable<StepDefinition> Parse(params Assembly[] assemblies)
        {
            return GetStepMethod(assemblies).Select(ParseStepDefinition);
        }

        private IEnumerable<MethodInfo> GetStepMethod(Assembly[] assemblies)
        {
            return GetBindingTypes(assemblies)
                .SelectMany(x => x.GetMethods())
                .Where(CheckStepAttribute);
        }

        private bool CheckStepAttribute(MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttributes()
                .Any(x => x is WhenAttribute || x is ThenAttribute || x is GivenAttribute);
        }
        
        private IEnumerable<Type> GetBindingTypes(Assembly[] assemblies)
        {
            return assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => x.GetCustomAttributes().OfType<BindingAttribute>().Any());
        }

        private StepDefinition ParseStepDefinition(MethodInfo methodInfo)
        {
            var stepDefinition = new StepDefinition();
            stepDefinition.MethodInfo = methodInfo;
            stepDefinition.StepAttributes.AddRange(ParseAttributes(methodInfo));
            return stepDefinition;
        }

        private IEnumerable<StepAttribute> ParseAttributes(MethodInfo methodInfo)
        {
            foreach (var attribute in methodInfo.GetCustomAttributes())
            {
                if (attribute is WhenAttribute whenAttribute)
                {
                    yield return new StepAttribute
                    {
                        StepType = StepType.When,
                        Regex = new Regex(whenAttribute.Regex)
                    };
                }

                if (attribute is ThenAttribute thenAttribute)
                {
                    yield return new StepAttribute
                    {
                        StepType = StepType.Then,
                        Regex = new Regex(thenAttribute.Regex)
                    };
                }

                if (attribute is GivenAttribute givenAttribute)
                {
                    yield return new StepAttribute
                    {
                        StepType = StepType.Given,
                        Regex = new Regex(givenAttribute.Regex)
                    };
                }
            }
        }
    }
}