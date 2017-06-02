using System.IO;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class FeatureFile
    {
        public FileInfo File { get; set; }
        public Feature Feature { get; } = new Feature();
    }
}