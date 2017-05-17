using AutoTests.Framework.PreProcessor.Tokens;

namespace AutoTests.Framework.PreProcessor
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