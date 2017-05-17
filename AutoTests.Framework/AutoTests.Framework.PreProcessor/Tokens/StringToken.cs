namespace AutoTests.Framework.PreProcessor.Tokens
{
    public class StringToken : Token
    {
        public override string Process()
        {
            return $"\"{Value}\"";
        }
    }
}