namespace AutoTests.Framework.TestData.Entities
{
    public class ResourceFileLocation
    {
        public string Directory { get; }

        public string Extension { get; }

        public ResourceFileLocation(string directory, string extension)
        {
            Directory = directory;
            Extension = extension;
        }
    }
}