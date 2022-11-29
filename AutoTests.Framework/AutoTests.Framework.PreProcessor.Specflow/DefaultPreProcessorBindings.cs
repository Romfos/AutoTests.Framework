using TechTalk.SpecFlow;

namespace AutoTests.Framework.PreProcessor.Specflow;

    [Binding]
    public class DefaultPreProcessorBindings
    {
        private readonly IPreProcessor preProcessor;

        public DefaultPreProcessorBindings(IPreProcessor preProcessor)
        {
            this.preProcessor = preProcessor;
        }

        [StepArgumentTransformation]
        public IExpression GetPreProcessorExpression(string text)
        {
            return new PreProcessorExpression(preProcessor, text);
        }
    }