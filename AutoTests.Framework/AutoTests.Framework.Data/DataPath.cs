using System.Linq;

namespace AutoTests.Framework.Data
{
    public struct DataPath
    {
        public string[] Nodes { get; }

        public DataPath(params string[] nodes)
        {
            Nodes = nodes;
        }

        public override bool Equals(object? obj)
        {
            return obj is DataPath path && Enumerable.SequenceEqual(Nodes, path.Nodes);
        }

        public override int GetHashCode()
        {
            return Nodes.Sum(x => x.Length);
        }
    }
}
