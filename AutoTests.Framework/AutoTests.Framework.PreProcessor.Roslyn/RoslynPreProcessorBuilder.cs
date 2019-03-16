using AutoTests.Framework.Core;

namespace AutoTests.Framework.PreProcessor.Roslyn
{
    public static class RoslynPreProcessorBuilder
    {
        public static AutoTestsFrameworkBuilder UseRoslynPreProcessor(
            this AutoTestsFrameworkBuilder autoTestsFrameworkBuilder)
        {
            return autoTestsFrameworkBuilder.Use(x => x.RegisterTypeAs<RoslynEvaluator, Evaluator>());
        }
    }
}