namespace AutoTests.Framework.Models;

public abstract class Model
{
    private readonly ModelInfo modelInfo;

    protected Model()
    {
        modelInfo = new ModelInfo(this);
    }

    public ModelInfo GetModelInfo()
    {
        return modelInfo;
    }
}
