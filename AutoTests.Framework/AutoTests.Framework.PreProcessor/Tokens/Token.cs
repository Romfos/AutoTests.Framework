namespace AutoTests.Framework.PreProcessor.Tokens
{
    public abstract class Token
    {
        public string Value { get; set; }

        public dynamic State { get; protected set; }

        public abstract string Process();
    }
}