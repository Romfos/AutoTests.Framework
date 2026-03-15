namespace AutoTests.Framework.Routing.Internal.Extensions;

internal static class PathExtensions
{
    extension(string path)
    {
        public string GetPathKey()
        {
            return new string(path.Where(x => !char.IsWhiteSpace(x)).ToArray());
        }
    }
}
