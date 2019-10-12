using AutoTests.Framework.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;

namespace AutoTests.Framework.Data.Loaders
{
    public class JsonDataHubLoader
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;

        public JsonDataHubLoader(EmbeddedResourceUtils embeddedResourceUtils)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
        }

        public void LoadJsonResource(DataHub dataHub, Assembly assembly, string resourceName, DataPath? basePath = null)
        {
            var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
            var jobject = JObject.Parse(content);
            var tokens = jobject.Descendants().OfType<JValue>();
            foreach(var token in tokens)
            {
                var localNodes = token.Path.Split('.');
                var nodes = basePath != null 
                    ? basePath.Value.Nodes.Concat(localNodes).ToArray() 
                    : localNodes;
                dataHub.Add(new DataPath(nodes), token.ToObject<object>());
            }
        }
    }
}
