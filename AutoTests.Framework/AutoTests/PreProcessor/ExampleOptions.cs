using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.PreProcessor.Entities.DateTimeEntites;

namespace AutoTests.PreProcessor
{
    public class ExampleOptions : Options
    {
        public ExampleOptions(Application application)
            : base(application.PreProcessor)
        {
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
                .Result(x => new DayEntity(int.Parse(x)));
        }

        private Token ParseDayConstant2(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsNumber)
                .ReadWhile(char.IsNumber)
                .Read(char.IsWhiteSpace, false)
                .ReadWhile(char.IsWhiteSpace, false)
                .Read("days", false)
                .Result(x => new DayEntity(int.Parse(x)));
        }
    }
}