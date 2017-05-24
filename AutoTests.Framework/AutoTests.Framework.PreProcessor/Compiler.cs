using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.PreProcessor.Exceptions;
using AutoTests.Framework.PreProcessor.Infrastructure;
using AutoTests.Framework.PreProcessor.Tokens;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace AutoTests.Framework.PreProcessor
{
    public class Compiler
    {
        private readonly Options options;
        private readonly ScriptOptions scriptOptions;

        public Compiler(PreProcessorDependencies dependencies)
        {
            options = dependencies.Options;

            scriptOptions = ScriptOptions.Default
                .AddReferences(options.References)
                .AddReferences(dependencies.Assemblies)
                .AddImports(options.Imports);
        }

        public T Compile<T>(string source)
        {
            return (T)Convert.ChangeType(Compile(source), typeof(T));
        }

        public object Compile(string source)
        {
            if (source.Trim().StartsWith("@"))
            {
                source = source.Trim().Substring(1);
                var tokens = Parse(source).ToArray();
                var roslynCode = Process(tokens);
                var runtime = new Runtime(tokens);
                return CSharpScript.EvaluateAsync(roslynCode, scriptOptions, runtime).Result;
            }
            return source;
        }

        private IEnumerable<Token> Parse(string soruce)
        {
            var stream = new Stream(soruce);

            while (!stream.End)
            {
                var token = options.Parsers.Select(parser => parser(stream)).FirstNotNull();
                if (token != null)
                {
                    yield return token;
                }
                else
                {
                    throw new CompilerException("Incorrect token");
                }
            }
        }

        private string Process(Token[] tokens)
        {
            return string.Concat(tokens.Select(Process));
        }

        private string Process(Token token, int index)
        {
            return token.Process().Replace("&", $"Tokens[{index}].State");
        }
    }
}