using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class Step
    {
        public StepType StepType { get; set; }
        public string Text { get; set; }
        public StepDefinition StepDefinition { get; set; }
        public Table Table { get; } = new Table();

        public override string ToString()
        {
            return $"{StepType} {Text}";
        }

        public StepAttribute GetStepAttribute()
        {
            return StepDefinition.StepAttributes.Single(x => x.StepType == StepType);
        }

        public string[] GetArguments()
        {
            return GetStepAttribute()
                .Regex.Match(Text)
                .Groups.Cast<Group>()
                .Skip(1)
                .Select(x => x.Value)
                .ToArray();
        }

        public bool IsArgumentType<T>()
        {
            return IsArgumentType(typeof(T));
        }

        public bool IsArgumentType(Type type)
        {
            var parameters = StepDefinition.MethodInfo.GetParameters();
            if (parameters.Length == 0)
            {
                return false;
            }
            return parameters.Last().ParameterType == type;
        }
    }
}