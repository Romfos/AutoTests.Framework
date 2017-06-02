using System.Collections.Generic;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class Feature
    {
        public string Name { get; set; }
        public List<Scenario> Scenarios { get; } = new List<Scenario>();
    }
}