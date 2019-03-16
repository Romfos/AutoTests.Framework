using System;
using BoDi;

namespace AutoTests.Framework.Core
{
    public class AutoTestsFrameworkBuilder
    {
        private readonly IObjectContainer objectContainer;

        public AutoTestsFrameworkBuilder(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public AutoTestsFrameworkBuilder Use(Action<IObjectContainer> action)
        {
            action(objectContainer);
            return this;
        }

        public T Build<T>()
            where T : ServiceProvider
        {
            return objectContainer.Resolve<T>();
        }
    }
}