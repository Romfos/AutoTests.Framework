namespace AutoTests.Framework.Expressions;

public class RoslynGlobals
{
    public dynamic Data { get; }

    public RoslynGlobals(dynamic data)
    {
        Data = data;
    }
}
