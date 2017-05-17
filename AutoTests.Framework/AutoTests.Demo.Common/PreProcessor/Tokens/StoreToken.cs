using AutoTests.Framework.PreProcessor.Tokens;

namespace AutoTests.Demo.Common.PreProcessor.Tokens
{
    public class StoreToken : Token
    {
        private readonly Application application;

        public StoreToken(Application application)
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