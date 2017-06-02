using System.Collections.Generic;
using System.Reflection;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class StepDefinition
    {
        public MethodInfo MethodInfo { get; set; }
        public List<StepAttribute> StepAttributes { get; } = new List<StepAttribute>();
    }
}