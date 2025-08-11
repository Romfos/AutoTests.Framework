using AutoTests.Framework;
using AutoTests.Framework.Playwright;
using BddDotNet;
using BddDotNet.Gherkin.CSharpExpressions;
using Bootstrap.Tests;
using Bootstrap.Tests.Pages;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Testing.Platform.Builder;
using System.Reflection;

var builder = await TestApplication.CreateBuilderAsync(args);

var services = builder.AddBddDotNet();

services.CSharpExpressions<CSharpExpressions>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"));
services.DynamicResourcesData([Assembly.GetExecutingAssembly()]);

services.SinglePageChromiumPlaywright(new() { Headless = false });
services.Page<BootstrapApplication>();

services.SourceGeneratedGherkinScenarios();
services.SourceGeneratedGherkinSteps();

using var testApp = await builder.BuildAsync();
return await testApp.RunAsync();
