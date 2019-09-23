using System.IO;
using System.Reflection;

namespace AutoTests.Framework.Core.Utils
{
    public class EmbeddedResourceUtils
    {
        public string GetLocalEmbeddedResourceText(Assembly assembly, string name)
        {
            using (var stream = assembly.GetManifestResourceStream(name))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
