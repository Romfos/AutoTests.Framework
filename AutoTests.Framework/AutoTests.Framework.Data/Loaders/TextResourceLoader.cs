using AutoTests.Framework.Core.Utils;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Data.Loaders;

    public class TextResourceLoader
    {
        private readonly EmbeddedResourceUtils embeddedResourceUtils;

        public TextResourceLoader(EmbeddedResourceUtils embeddedResourceUtils)
        {
            this.embeddedResourceUtils = embeddedResourceUtils;
        }

        public void LoadTextResource(DataHub dataHub, Assembly assembly, string resourceName, DataPath path)
        {
            var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
            dataHub.Add(path, content);
        }

        public void LoadTextResources(DataHub dataHub, Assembly assembly, Regex regex, DataPath? basePath = null)
        {
            var resourceNames = embeddedResourceUtils.GetLocalEmbeddedResourceNames(assembly, regex);
            foreach (var resourceName in resourceNames)
            {
                var content = embeddedResourceUtils.GetLocalEmbeddedResourceText(assembly, resourceName);
                var contentPath = new DataPath(regex.Match(resourceName).Groups[1].Value.Split('.'));
                var path = DataPath.Combine(basePath, contentPath);
                dataHub.Add(path, content);
            }
        }
    }
