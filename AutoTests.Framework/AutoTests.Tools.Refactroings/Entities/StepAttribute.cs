using System.Text.RegularExpressions;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class StepAttribute
    {
        public StepType StepType { get; set; }
        public Regex Regex { get; set; }
    }
}