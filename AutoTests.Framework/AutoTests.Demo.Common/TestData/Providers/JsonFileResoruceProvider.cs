using System;
using System.Collections.Generic;
using AutoTests.Framework.TestData.Entities;
using AutoTests.Framework.TestData.TestDataProviders.FileResoruceProviders;

namespace AutoTests.Demo.Common.TestData.Providers
{
    public class JsonFileResoruceProvider : JsonFileResoruceProviderBase
    {
        protected override IEnumerable<ResourceFileLocation> GetFileLocations()
        {
            yield return new ResourceFileLocation(Environment.CurrentDirectory + @"\TestData\Files", "json");
        }
    }
}