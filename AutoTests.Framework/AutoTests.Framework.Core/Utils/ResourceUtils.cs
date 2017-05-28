using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Core.Utils
{
    public class ResourceUtils
    {
        public string GetTextResource(object target, string filename)
        {
            var type = target.GetType();
            var assembly = type.Assembly;
            var resourceName = $"{type.Namespace}.{filename}";

            return GetTextResource(assembly, resourceName);
        }

        public string GetTextResource(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public bool CheckResource(object target, string filename)
        {
            var type = target.GetType();
            var assembly = type.Assembly;
            var resourceName = $"{type.Namespace}.{filename}";

            return assembly.GetManifestResourceNames().Any(x => x == resourceName);
        }

        public JObject GetJsonResource(object target, string filename)
        {
            return JObject.Parse(GetTextResource(target, filename));
        }

        public JObject GetJsonResource(Assembly assembly, string resourceName)
        {
            return JObject.Parse(GetTextResource(assembly, resourceName));
        }
    }
}