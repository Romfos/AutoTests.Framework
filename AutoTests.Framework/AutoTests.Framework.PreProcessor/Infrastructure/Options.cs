using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Extensions;

namespace AutoTests.Framework.PreProcessor.Infrastructure
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
                ParseAssetMember,
                ParseString,
                ParseString2,
                ParseStoreLink,
                ParseResourceLink,
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
            return stream.ReadToken().Read(@operator).Result(x => null, x => x);
        }

        private Token ParseString(Stream stream)
        {
            return stream.ReadToken()
                .Read('"', false)
                .ReadWhile(x => x != '"')
                .Read('"', false)
                .Result(x => $"\"{x}\"");
        }

        private Token ParseString2(Stream stream)
        {
            return stream.ReadToken()
                .Read('\'', false)
                .ReadWhile(x => x != '\'')
                .Read('\'', false)
                .Result(x => $"\"{x}\"");
        }

        private Token ParseTrivia(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsWhiteSpace)
                .ReadWhile(char.IsWhiteSpace)
                .Result(x => null, x => x);
        }

        private Token ParseDouble(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsDigit)
                .ReadWhile(char.IsDigit)
                .Read('.')
                .Read(char.IsDigit)
                .ReadWhile(char.IsDigit)
                .Result(x => double.Parse(x));
        }

        private Token ParseInteger(Stream stream)
        {
            return stream.ReadToken()
                .Read(char.IsDigit)
                .ReadWhile(char.IsDigit)
                .Result(x => int.Parse(x));
        }

        private Token ParseAssetMember(Stream stream)
        {
            Asset targetAsset = null;

            return stream.ReadToken()
                .Read(x => char.IsLetter(x) || x == '_')
                .ReadWhile(x => char.IsLetterOrDigit(x) || x == '_')
                .Check(x => FindAsset(x, out targetAsset))
                .Result(x => targetAsset, x => $"&.{x}");
        }

        private bool FindAsset(string memberName, out Asset targetAsset)
        {
            foreach (var asset in Assets)
            {
                foreach (var member in asset.GetType().GetMembers())
                {
                    if (member.Name == memberName)
                    {
                        targetAsset = asset;
                        return true;
                    }
                }
            }
            targetAsset = null;
            return false;
        }
        
        private Token ParseStoreLink(Stream stream)
        {
            return stream.ReadToken()
                .Read('[', false)
                .Read(x => x != ']')
                .ReadWhile(x => x != ']')
                .Read(']', false)
                .Result(x => dependencies.Stores.ObjectStore[x]);
        }

        private Token ParseResourceLink(Stream stream)
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
            result = dependencies.ResourceMananger.GetResource(name);
            return result != null;
        }
    }
}