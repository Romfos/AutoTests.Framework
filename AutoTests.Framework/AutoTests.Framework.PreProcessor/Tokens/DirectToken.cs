namespace AutoTests.Framework.PreProcessor.Tokens
{
    public class DirectToken : Token
    {
        public override string Process()
        {
            return Value;
        }
    }
}