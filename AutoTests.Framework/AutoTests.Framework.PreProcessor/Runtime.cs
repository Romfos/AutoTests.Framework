using AutoTests.Framework.PreProcessor.Tokens;

namespace AutoTests.Framework.PreProcessor
{
    public class Runtime
    {
        public Token[] Token { get; }

        public Runtime(Token[] token)
        {
            Token = token;
        }
    }
}