using System;
using System.Linq;

namespace AutoTests.Framework.Data;

public struct DataPath
{
    public string[] Nodes { get; }

    public DataPath(params string[] nodes)
    {
        Nodes = nodes;
    }

    public static DataPath Empty { get; } = new DataPath(Array.Empty<string>());

    public static DataPath Combine(params DataPath?[] dataPaths)
    {
        var nodes = dataPaths
            .Where(x => x.HasValue)
            .Select(x => x!.Value)
            .SelectMany(x => x.Nodes)
            .ToArray();
        return new DataPath(nodes);
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
