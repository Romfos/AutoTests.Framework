using System.Collections.Generic;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class Scenario
    {
        public string Name { get; set; }
        public List<Step> Steps { get; } = new List<Step>();
        public Example Example { get; } = new Example();
    }
}