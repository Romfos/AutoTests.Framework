using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor.Specflow;

public class PreProcessorExpression : IExpression
{
    private readonly IPreProcessor preProcessor;
    private readonly string text;

    public PreProcessorExpression(IPreProcessor preProcessor, string text)
    {
        this.preProcessor = preProcessor;
        this.text = text;
    }

    public async Task<T> ExecuteAsync<T>()
    {
        return await preProcessor.ExecuteAsync<T>(text);
    }
}
