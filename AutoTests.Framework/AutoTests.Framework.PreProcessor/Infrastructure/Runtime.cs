namespace AutoTests.Framework.PreProcessor.Infrastructure
{
    public class Runtime
    {
        public Token[] Tokens { get; }

        public Runtime(Token[] tokens)
        {
            Tokens = tokens;
        }
    }
}