using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Core.Utils;

public class EmbeddedResourceUtils
{
    public IEnumerable<string> GetLocalEmbeddedResourceNames(Assembly assembly, Regex regex)
    {
        return assembly.GetManifestResourceNames().Where(x => regex.IsMatch(x));
    }

    public bool DoesLocalEmbeddedResourceExist(Assembly assembly, string name)
    {
        return assembly.GetManifestResourceNames().Contains(name);
    }

    public string GetLocalEmbeddedResourceText(Assembly assembly, string name)
    {
        using (var stream = assembly.GetManifestResourceStream(name))
        {
            using (var reader = new StreamReader(stream!))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
