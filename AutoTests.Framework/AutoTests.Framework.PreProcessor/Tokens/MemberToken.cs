using System;
using System.Linq;

namespace AutoTests.Framework.PreProcessor.Tokens
{
    public class MemberToken : Token
    {
        private readonly Options options;

        public MemberToken(Options options)
        {
            this.options = options;
        }

        public override string Process()
        {
            foreach (var asset in options.Assets)
            {
                if (asset.GetType().GetMembers().Any(x => x.Name == Value))
                {
                    State = asset;
                    return $"@.{Value}";
                }
            }
            throw new NotImplementedException();
        }
    }
}