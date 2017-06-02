using System.Collections.Generic;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class Feature
    {
        public List<string> Tags { get; } = new List<string>();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Scenario> Scenarios { get; } = new List<Scenario>();

        public override string ToString()
        {
            return $"Feature: {Name}";
        }
    }
}