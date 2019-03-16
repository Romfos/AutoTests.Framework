using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace AutoTests.Framework.Core.Utils
{
    public class EmbeddedResourcesUtils
    {
        public EmbeddedResourcesUtils(UtilsServiceProvider serviceProvider)
        {
        }

        public bool IsResourceExist(object target, string fileName)
        {
            var type = target.GetType();
            var resourceName = $"{target.GetType().Namespace}.{fileName}";
            return type.Assembly.GetManifestResourceNames().Any(x => x == resourceName);
        }

        public JObject GetJsonResourceContent(object target, string fileName)
        {
            var content = GetTextResourceContent(target, fileName);
            return JObject.Parse(content);
        }

        public string GetTextResourceContent(object target, string fileName)
        {
            var type = target.GetType();
            var resourceName = $"{target.GetType().Namespace}.{fileName}";
            using (var stream = type.Assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}