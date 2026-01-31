using AutoTests.Framework.Playwright.AI;
using BddDotNet;
using BddDotNet.Gherkin.CSharpExpressions;
using Bootstrap.Tests.AI;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Testing.Platform.Builder;
using OllamaSharp;
using System.Diagnostics;
using System.Reflection;

var builder = await TestApplication.CreateBuilderAsync(args);

var services = builder.AddBddDotNet();

services.CSharpExpressions<CSharpExpressions>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"));
services.DynamicResourcesData([Assembly.GetExecutingAssembly()]);

services.AddChatClient(new OllamaApiClient(new Uri("http://localhost:11434"), "ministral-3:8b"));
services.SinglePageChromiumPlaywrightWithAILearning(new() { Headless = !Debugger.IsAttached }, "OptionsCache.json"); //make browser visible during local debug

services.SourceGeneratedGherkinScenarios();

using var testApp = await builder.BuildAsync();
return await testApp.RunAsync();
