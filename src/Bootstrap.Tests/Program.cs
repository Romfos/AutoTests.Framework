using AutoTests.Framework;
using AutoTests.Framework.Playwright;
using BddDotNet;
using BddDotNet.Gherkin.CSharpExpressions;
using Bootstrap.Tests;
using Bootstrap.Tests.Pages;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Testing.Platform.Builder;
using System.Diagnostics;
using System.Reflection;

var builder = await TestApplication.CreateBuilderAsync(args);

var services = builder.AddBddDotNet();

services.CSharpExpressions<CSharpExpressions>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"));
services.DynamicResourcesData([Assembly.GetExecutingAssembly()]);

services.SinglePageChromiumPlaywright(new() { Headless = !Debugger.IsAttached }); //make browser visible during local debug

services.Page<BootstrapApplication>();

services.SourceGeneratedGherkinScenarios();
services.SourceGeneratedGherkinSteps();

using var testApp = await builder.BuildAsync();
return await testApp.RunAsync();
