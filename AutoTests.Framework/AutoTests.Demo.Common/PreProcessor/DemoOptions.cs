using AutoTests.Demo.Common.PreProcessor.Tokens;
using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.PreProcessor.Tokens;

namespace AutoTests.Demo.Common.PreProcessor
{
    public class DemoOptions : Options
    {
        private readonly Application application;

        public DemoOptions(Application application)
            : base(application.PreProcessor)
        {
            this.application = application;

            Parsers.Insert(0, ParseStoreLink);
        }

        private Token ParseStoreLink(Stream stream)
        {
            return stream.ReadToken()
                .Read('[', false)
                .Read(x => x != ']')
                .ReadWhile(x => x != ']')
                .Read(']', false)
                .Result(() => application.PreProcessor.CreateToken<StoreToken>());
        }
    }
}