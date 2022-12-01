namespace AutoTests.Framework.Expressions;

public sealed class RoslynGlobals
{
    public dynamic Data { get; }

    public RoslynGlobals(dynamic data)
    {
        Data = data;
    }
}
