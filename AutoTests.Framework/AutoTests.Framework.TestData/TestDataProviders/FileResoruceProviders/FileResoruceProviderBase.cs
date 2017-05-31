using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoTests.Framework.TestData.Entities;

namespace AutoTests.Framework.TestData.TestDataProviders.FileResoruceProviders
{
    public abstract class FileResoruceProviderBase : TestDataProvider
    {
        private Dictionary<string, string> resources;
        
        public override void LoadResoruces()
        {
            resources = GetFileLocations()
                .SelectMany(LoadResources)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public override object GetResoruce(string name)
        {
            return resources.ContainsKey(name) ? resources[name] : null;
        }

        protected abstract IEnumerable<ResourceFileLocation> GetFileLocations();

        protected IEnumerable<KeyValuePair<string, string>> LoadResources(ResourceFileLocation location)
        {
            var files = new DirectoryInfo(location.Directory)
                .GetFiles("*." + location.Extension, SearchOption.AllDirectories);
            
            return files.SelectMany(file => ParseResource(file, GetResourceName(location, file)));
        }

        private string GetResourceName(ResourceFileLocation location, FileInfo file)
        {
            var fileUri = new Uri(file.FullName, UriKind.Absolute);
            var directory = location.Directory.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            var directoryUri = new Uri(directory, UriKind.Absolute);
            var relativeUri = directoryUri.MakeRelativeUri(fileUri).ToString();

            return relativeUri
                .Substring(0, relativeUri.Length - 1 - location.Extension.Length)
                .Replace(Path.AltDirectorySeparatorChar.ToString(), ".");
        }
        
        protected abstract IEnumerable<KeyValuePair<string, string>> ParseResource(FileInfo file, string name);
    }
}