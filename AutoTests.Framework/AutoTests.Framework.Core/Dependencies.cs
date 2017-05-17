using BoDi;

namespace AutoTests.Framework.Core
{
    public abstract class Dependencies
    {
        protected ObjectContainer ObjectContainer { get; }

        protected Dependencies(ObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        public abstract void Setup();
    }
}