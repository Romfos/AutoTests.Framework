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
            Parsers.Insert(0, ParseDayConstant);
            Parsers.Insert(0, ParseDayConstant2);
        }

        private Token ParseDayConstant(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsNumber)
                .ReadWhile(char.IsNumber)
                .Read(char.IsWhiteSpace, false)
                .ReadWhile(char.IsWhiteSpace, false)
                .Read("day", false)
                .Result(() => application.PreProcessor.CreateToken<DayConstantToken>());
        }

        private Token ParseDayConstant2(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsNumber)
                .ReadWhile(char.IsNumber)
                .Read(char.IsWhiteSpace, false)
                .ReadWhile(char.IsWhiteSpace, false)
                .Read("days", false)
                .Result(() => application.PreProcessor.CreateToken<DayConstantToken>());
        }
    }
}