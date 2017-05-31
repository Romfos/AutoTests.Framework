using System.Collections.Generic;
using System.IO;

namespace AutoTests.Framework.TestData.TestDataProviders.FileResoruceProviders
{
    public abstract class TextFileResoruceProviderBase : FileResoruceProviderBase
    {
        protected override IEnumerable<KeyValuePair<string, string>> ParseResource(FileInfo file, string name)
        {
            yield return new KeyValuePair<string, string>(name, File.ReadAllText(file.FullName));
        }
    }
}