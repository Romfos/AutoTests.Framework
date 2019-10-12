using System.Collections.Generic;

namespace AutoTests.Framework.Data
{
    public struct DataPath
    {
        public string[] Nodes { get; }

        public DataPath(string[] nodes)
        {
            Nodes = nodes;
        }

        public override bool Equals(object? obj)
        {
            return obj is DataPath path &&
                   EqualityComparer<string[]>.Default.Equals(Nodes, path.Nodes);
        }

        public override int GetHashCode()
        {
            return 249714186 + EqualityComparer<string[]>.Default.GetHashCode(Nodes);
        }
    }
}
