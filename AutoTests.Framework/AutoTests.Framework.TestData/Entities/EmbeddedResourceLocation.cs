using System.Reflection;

namespace AutoTests.Framework.TestData.Entities
{
    public class EmbeddedResourceLocation
    {
        public Assembly Assembly { get; }
        public string Pattern { get; }

        public EmbeddedResourceLocation(Assembly assembly, string pattern)
        {
            Assembly = assembly;
            Pattern = pattern;
        }
    }
}