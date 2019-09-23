using TechTalk.SpecFlow;

namespace AutoTests.Framework.PreProcessor.Specflow
{
    [Binding]
    public class PreProcessorStepTransformations
    {
        private readonly IPreProcessor preProcessor;

        public PreProcessorStepTransformations(IPreProcessor preProcessor)
        {
            this.preProcessor = preProcessor;
        }

        [StepArgumentTransformation]
        public Calculated Calculated(string text)
        {
            return new Calculated(preProcessor, text);
        }
    }
}