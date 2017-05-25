using AutoTests.Framework.PreProcessor;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.PreProcessor.Tokens;
using AutoTests.PreProcessor.Tokens;

namespace AutoTests.PreProcessor
{
    public class ExampleOptions : Options
    {
        private readonly Application application;

        public ExampleOptions(Application application)
            : base(application.PreProcessor)
        {
            this.application = application;
            Parsers.Insert(0, ParseContextLink);
        }

        private Token ParseContextLink(Stream stream)
        {
            return stream.ReadToken()
                .Read('[', false)
                .Read(x => x != ']')
                .ReadWhile(x => x != ']')
                .Read(']', false)
                .Result(() => application.PreProcessor.CreateToken<StoreLinkToken>());
        }
    }
}