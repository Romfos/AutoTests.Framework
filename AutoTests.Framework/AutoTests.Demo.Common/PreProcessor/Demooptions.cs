using AutoTests.Framework.PreProcessor.Infrastructure;

namespace AutoTests.Demo.Common.PreProcessor
{
    public class DemoOptions : Options
    {
        private readonly Application application;

        public DemoOptions(Application application) : base(application.PreProcessor)
        {
            this.application = application;
            Parsers.Insert(0, ParseResourceToken);
        }

        private Token ParseResourceToken(Stream stream)
        {
            object resource = null;

            return stream.ReadToken()
                .Read(char.IsLetter)
                .ReadWhile(x => char.IsLetterOrDigit(x) || x == '.')
                .Check(x => GetResource(x, out resource))
                .Result(x => resource);
        }

        private bool GetResource(string name, out object result)
        {
            result = application.Resources.Mananger.GetResource(name);
            return result != null;
        }
    }
}