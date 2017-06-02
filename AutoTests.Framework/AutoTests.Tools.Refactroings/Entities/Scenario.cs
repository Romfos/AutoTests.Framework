﻿using System.Collections.Generic;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class Scenario
    {
        public List<string> Tags { get; } = new List<string>();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Step> Steps { get; } = new List<Step>();
        public List<Examples> Examples { get; } = new List<Examples>();

        public override string ToString()
        {
            return $"Scenario: {Name}";
        }
    }
}