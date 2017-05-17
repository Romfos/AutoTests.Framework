using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.PreProcessor.Assets;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.PreProcessor.Tokens;

namespace AutoTests.Framework.PreProcessor
{
    public class Options
    {
        private readonly PreProcessorDependencies dependencies;

        public List<Asset> Assets { get; }
        public List<Parser> Parsers { get; }
        public List<string> Imports { get; }
        public List<string> References { get; }

        public Options(PreProcessorDependencies dependencies)
        {
            this.dependencies = dependencies;
            Assets = dependencies.GetAssets().ToList();
            Imports = new List<string>();

            Parsers = new List<Parser>
            {
                ParseTrivia,
                ParseDouble,
                ParseInteger,
                ParseIdentificator,
                ParseString,
                ParseString2,
                ParseOperators
            };

            References = new List<string>
            {
                "Microsoft.CSharp"
            };
        }

        private Token ParseOperators(Stream stream)
        {
            return "+-*/(,)".Select(x => ParseOperator(stream, x)).FirstNotNull();
        }

        private Token ParseOperator(Stream stream, char @operator)
        {
            return stream.ReadToken().Read(@operator).Result(() => dependencies.CreateToken<DirectToken>());
        }

        private Token ParseString(Stream stream)
        {
            return stream.ReadToken()
                .Read('"', false)
                .ReadWhile(x => x != '"')
                .Read('"', false)
                .Result(() => dependencies.CreateToken<StringToken>());
        }

        private Token ParseString2(Stream stream)
        {
            return stream.ReadToken()
                .Read('\'', false)
                .ReadWhile(x => x != '\'')
                .Read('\'', false)
                .Result(() => dependencies.CreateToken<StringToken>());
        }

        private Token ParseTrivia(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsWhiteSpace)
                .ReadWhile(char.IsWhiteSpace)
                .Result(() => dependencies.CreateToken<DirectToken>());
        }

        private Token ParseDouble(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsDigit)
                .ReadWhile(char.IsDigit)
                .Read('.')
                .Read(char.IsDigit)
                .ReadWhile(char.IsDigit)
                .Result(() => dependencies.CreateToken<DirectToken>());
        }

        private Token ParseInteger(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsDigit)
                .ReadWhile(char.IsDigit)
                .Result(() => dependencies.CreateToken<DirectToken>());
        }

        private Token ParseIdentificator(Stream stream)
        {
            return stream.ReadToken()
                .Read(x => char.IsLetter(x) || x == '_')
                .ReadWhile(x => char.IsLetterOrDigit(x) || x == '_')
                .Result(() => dependencies.CreateToken<MemberToken>());
        }
    }
}