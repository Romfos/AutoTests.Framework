using AutoTests.Framework.PreProcessor.Tokens;

namespace AutoTests.PreProcessor.Tokens
{
    public class StoreLinkToken  : Token
    {
        private readonly Application application;

        public StoreLinkToken(Application application)
        {
            this.application = application;
        }

        public override string Process()
        {
            State = application.Stores.ObjectStore[Value];
            return "&";
        }
    }
}