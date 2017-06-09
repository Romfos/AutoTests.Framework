using System.Collections.Generic;
using AutoTests.Tools.Refactroings.Entities;

namespace AutoTests.Tools.Refactroings.Refactroings
{
    public abstract class Refactroings
    {
        protected List<FeatureFile> FeatureFiles { get; }

        protected Refactroings(List<FeatureFile> featureFiles)
        {
            FeatureFiles = featureFiles;
        }
    }
}