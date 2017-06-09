using System.Text.RegularExpressions;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class StepAttribute
    {
        public StepType StepType { get; set; }
        public Regex Regex { get; set; }

        public override string ToString()
        {
            return $"[{StepType}(\"{Regex}\")]";
        }
        
        public override bool Equals(object obj)
        {
            return obj is StepAttribute stepAttribute
                   && StepType == stepAttribute.StepType
                   && Regex.ToString() == stepAttribute.Regex.ToString();
        }
    }
}