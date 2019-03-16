using BoDi;

namespace AutoTests.Framework.Core
{
    public abstract class ServiceProvider
    {
        protected IObjectContainer ObjectContainer { get; }

        protected ServiceProvider(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }
    }
}