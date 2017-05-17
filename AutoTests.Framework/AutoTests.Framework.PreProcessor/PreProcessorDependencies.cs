using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoTests.Framework.Core;
using AutoTests.Framework.PreProcessor.Assets;
using AutoTests.Framework.PreProcessor.Tokens;
using BoDi;

namespace AutoTests.Framework.PreProcessor
{
    public class PreProcessorDependencies : Dependencies
    {
        public PreProcessorDependencies(ObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public Compiler Compiler => ObjectContainer.Resolve<Compiler>();

        public Options Options => ObjectContainer.Resolve<Options>();

        internal Assembly[] Assemblies => ObjectContainer.Resolve<Assembly[]>();

        public override void Setup()
        {
        }

        public IEnumerable<Asset> GetAssets()
        {
            return Assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Asset)))
                .Select(x => (Asset) ObjectContainer.Resolve(x));
        }

        public T CreateToken<T>()
            where T : Token
        {
            var type = typeof(T);

            var arguments = type
                .GetConstructors()
                .Single()
                .GetParameters()
                .Select(x => ObjectContainer.Resolve(x.ParameterType))
                .ToArray();

            return (T) Activator.CreateInstance(type, arguments);
        }
    }
}