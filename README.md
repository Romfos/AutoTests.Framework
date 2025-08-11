# Overview

Reqnroll based autotest framework

[![.github/workflows/test.yml](https://github.com/Romfos/AutoTests.Framework/actions/workflows/test.yml/badge.svg)](https://github.com/Romfos/AutoTests.Framework/actions/workflows/test.yml)

[![AutoTests.Framework.Playwright](https://img.shields.io/nuget/v/AutoTests.Framework.Playwright?label=AutoTests.Framework.Playwright)](https://www.nuget.org/packages/AutoTests.Framework.Playwright)

BddDotNet based autotest framework

Key features:
- Gherkin syntax support
- C# expressions support for Gherkin syntax
- Component framework for UI testing
- Page object pattern support
- Playwright integration
- Test data management framework

# Test example
```gherkin
Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl'
    When set following values:
    | Name                  | Value      |
    | checkout > first name | first_name |
    | checkout > last name  | last_name  |
    And click on 'checkout > continue to checkout'
    Then should be visible:
    | Name                              |
    | checkout > username error message |
    And should have following values:
    | Name                              | Value                      |
    | checkout > username error message | Your username is required. |
```

# Requirements
- .NET 8+
- Visual Studio 2022 or Visual Studio Code
- [Reqnroll plugin](https://marketplace.visualstudio.com/items?itemName=Reqnroll.ReqnrollForVisualStudio2022) for Visual Studio 2022 or [Cucumber plugin](https://marketplace.visualstudio.com/items?itemName=CucumberOpen.cucumber-official) for Visual Studio Code

# Nuget packages links  
- https://www.nuget.org/packages/AutoTests.Framework
- https://www.nuget.org/packages/AutoTests.Framework.Playwright

# How to use
You can find example in Bootstrap.Tests project for UI testing

Guide:
1) Create new console application for .NET 9
2) Install nuget packages:

| Nuget package                              | Link                                                                                                                                                                                                     |
|--------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AutoTests.Framework.Playwright             | [AutoTests.Framework.Playwright](https://www.nuget.org/packages/AutoTests.Framework.Playwright)                                                                                                          |
| BddDotNet.Gherkin.SourceGenerator          | [BddDotNet.Gherkin.SourceGenerator](https://www.nuget.org/packages/BddDotNet.Gherkin.SourceGenerator)                                                                                                    |
| Microsoft.Playwright                       | [Microsoft.Playwright](https://www.nuget.org/packages/Microsoft.Playwright)                                                                                                                              |

3) Configure application in `Program.cs`. Example:
```csharp
using AutoTests.Framework;
using AutoTests.Framework.Playwright;
using BddDotNet;
using Bootstrap.Tests.Pages;
using Microsoft.Testing.Platform.Builder;

var builder = await TestApplication.CreateBuilderAsync(args);

var services = builder.AddBddDotNet();

services.SinglePageChromiumPlaywright(new() { Headless = false });
services.Page<BootstrapApplication>();

services.SourceGeneratedGherkinScenarios();
services.SourceGeneratedGherkinSteps();

using var testApp = await builder.BuildAsync();
return await testApp.RunAsync();
```

4) Add page objects. Example:

```csharp
using AutoTests.Framework.Pages;

namespace Bootstrap.Tests.Pages;

internal sealed class BootstrapApplication
{
    [Route("checkout")]
    public required Checkout Checkout { get; init; }
}

internal sealed class Checkout
{
    [Route("continue to checkout")]
    [Options(".btn-primary")]
    public required Button ContinueToCheckout { get; init; }

    [Route("first name")]
    [Options("#firstName")]
    public required Input FirstName { get; init; }

    [Route("last name")]
    [Options("#lastName")]
    public required Input LastName { get; init; }

    [Route("username error message")]
    [Options("#username ~ .invalid-feedback")]
    public required Label UsernameErrorMessage { get; init; }
}
```

# How to make C# expressions and json data from resources avaiable in gherkin feature files

1) Install `BddDotNet.Gherkin.CSharpExpressions` nuget package
2) Add service with C# expressions
```csharp
using AutoTests.Framework.Resources;

namespace Bootstrap.Tests;

public sealed class CSharpExpressions(IDynamicDataService dynamicDataService)
{
    public dynamic Data { get; } = dynamicDataService.Data;
}
```
4) Configure `BddDotNet.Gherkin.CSharpExpressions` in `Program.cs`
```csharp
services.CSharpExpressions<CSharpExpressions>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"));
services.DynamicResourcesData([Assembly.GetExecutingAssembly()]);
```

You can create json file in Data subfolder and get access to content in feature to it like:
```gherkin
Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl' #return value HomePageUrl from Data\Common.json
```
You can find example in 'Bootstrap.Tests'


