using AutoTests.Framework.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Data.Loaders
{
    public class JsonResourceLoader
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;

        public JsonResourceLoader(EmbeddedResourceUtils embeddedResourceUtils)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
        }

        public void LoadJsonResource(DataHub dataHub, Assembly assembly, string resourceName, DataPath? basePath = null)
        {
            var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
            var jobject = JObject.Parse(content);
            AddJsonObjectToDataHub(dataHub, jobject, basePath);
        }

        public void LoadJsonResources(DataHub dataHub, Assembly assembly, 
            Regex regex, bool includeResourceName = true, DataPath? basePath = null)
        {
            var resourceNames = embeddedResourceUtils.GetLocalEmbeddedResourceNames(assembly, regex);
            foreach(var resourceName in resourceNames)
            {
                var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
                var contentPath = new DataPath(regex.Match(resourceName).Groups[1].Value.Split('.'));
                var jobject = JObject.Parse(content);
                var fullBasePath = includeResourceName ? DataPath.Combine(basePath, contentPath) : basePath;
                AddJsonObjectToDataHub(dataHub, jobject, fullBasePath);
            }
        }

        private void AddJsonObjectToDataHub(DataHub dataHub, JObject jobject, DataPath? basePath = null)
        {
            var tokens = jobject.Descendants().OfType<JValue>();
            foreach (var token in tokens)
            {
                var nodes = token.Path.Split('.');
                var dataPath = DataPath.Combine(basePath, new DataPath(nodes));
                dataHub.Add(dataPath, token.ToObject<object>());
            }
        }
    }
}
