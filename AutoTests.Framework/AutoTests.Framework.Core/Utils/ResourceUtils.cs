using System.IO;
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

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public JObject GetJsonResource(object target, string filename)
        {
            return JObject.Parse(GetTextResource(target, filename));
        }
    }
}