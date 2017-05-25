using AutoTests.Framework.Core.Stores;

namespace AutoTests.Framework.PreProcessor.Tokens
{
    public class StoreLinkToken : Token
    {
        private readonly StoresDependencies dependencies;

        public StoreLinkToken(StoresDependencies dependencies)
        {
            this.dependencies = dependencies;
        }

        public override string Process()
        {
            State = dependencies.ObjectStore[Value];
            return "&";
        }
    }
}