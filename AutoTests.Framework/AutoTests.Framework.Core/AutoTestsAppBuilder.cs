namespace AutoTests.Framework.Core;

public class AutoTestsAppBuilder
{
    public IContainer Container { get; }

    public AutoTestsAppBuilder(IContainer container)
    {
        Container = container;
    }
}
