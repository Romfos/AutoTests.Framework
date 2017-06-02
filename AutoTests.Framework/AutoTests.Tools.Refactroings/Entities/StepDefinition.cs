using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class StepDefinition
    {
        public MethodInfo MethodInfo { get; set; }
        public List<StepAttribute> StepAttributes { get; } = new List<StepAttribute>();

        public override string ToString()
        {
            return $"{MethodInfo.DeclaringType.Name}.{MethodInfo.Name}";
        }

        public bool IsEnumerableArgument()
        {
            var parameters = MethodInfo.GetParameters();
            if (parameters.Length == 0)
            {
                return false;
            }
            return typeof(IEnumerable).IsAssignableFrom(parameters.Last().ParameterType);
        }
    }
}