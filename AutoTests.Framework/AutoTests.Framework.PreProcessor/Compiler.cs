﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Extensions;
using AutoTests.Framework.PreProcessor.Exceptions;
using AutoTests.Framework.PreProcessor.Infrastructure;
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
                .AddReferences(dependencies.Core.Assemblies)
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
                var code = GetCode(tokens);
                var runtime = new Runtime(tokens);
                return CSharpScript.EvaluateAsync(code, scriptOptions, runtime).Result;
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

        private string GetCode(Token[] tokens)
        {
            return string.Concat(tokens.Select(GetTokenCode));
        }

        private string GetTokenCode(Token token, int index)
        {
            return token.Source.Replace("&", $"Tokens[{index}].State");
        }
    }
}