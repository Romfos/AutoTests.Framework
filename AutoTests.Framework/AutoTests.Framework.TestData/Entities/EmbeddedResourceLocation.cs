using System.Reflection;

namespace AutoTests.Framework.TestData.Entities
{
    public class EmbeddedResourceLocation
    {
        public Assembly Assembly { get; }
        public string Regex { get; }

        public EmbeddedResourceLocation(Assembly assembly, string regex)
        {
            Assembly = assembly;
            Regex = regex;
        }
    }
}