using TechTalk.SpecFlow;

namespace AutoTests.Framework.PreProcessor.Specflow
{
    [Binding]
    public class DefaultPreProcessortBindings
    {
        private readonly IPreProcessor preProcessor;

        public DefaultPreProcessortBindings(IPreProcessor preProcessor)
        {
            this.preProcessor = preProcessor;
        }

        [StepArgumentTransformation]
        public IExpression GetPreProcessorExpression(string text)
        {
            return new PreProcessorExpression(preProcessor, text);
        }
    }
}