# Overview

[BddDotNet](https://github.com/Romfos/BddDotNet) based autotest framework with Playwright integration

[![.github/workflows/test.yml](https://github.com/Romfos/AutoTests.Framework/actions/workflows/test.yml/badge.svg)](https://github.com/Romfos/AutoTests.Framework/actions/workflows/test.yml)

[![AutoTests.Framework.Playwright](https://img.shields.io/nuget/v/AutoTests.Framework.Playwright?label=AutoTests.Framework.Playwright)](https://www.nuget.org/packages/AutoTests.Framework.Playwright)

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

| Description                                                               | Package                                                                                                                                                                                                                    |
|---------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Add AutoTests.Framework with Playwright integration                       | [![AutoTests.Framework.Playwright](https://img.shields.io/nuget/v/AutoTests.Framework.Playwright?label=AutoTests.Framework.Playwright)](https://www.nuget.org/packages/AutoTests.Framework.Playwright)                     |
| Add Gherkin language support                                              | [![BddDotNet.Gherkin.SourceGenerator](https://img.shields.io/nuget/v/BddDotNet.Gherkin.SourceGenerator?label=BddDotNet.Gherkin.SourceGenerator)](https://www.nuget.org/packages/BddDotNet.Gherkin.SourceGenerator)         |
| Official Playwright package                                               | [![Microsoft.Playwright](https://img.shields.io/nuget/v/Microsoft.Playwright?label=Microsoft.Playwright)](https://www.nuget.org/packages/Microsoft.Playwright)                                                             |
| (Optional) Add argument transformations for Gherkin tables into C# models | [![BddDotNet.Gherkin.Models](https://img.shields.io/nuget/v/BddDotNet.Gherkin.Models?label=BddDotNet.Gherkin.Models)](https://www.nuget.org/packages/BddDotNet.Gherkin.Models)                                             |
| (Optional) Adding support for C# expressions for arguments                | [![BddDotNet.Gherkin.CSharpExpressions](https://img.shields.io/nuget/v/BddDotNet.Gherkin.CSharpExpressions?label=BddDotNet.Gherkin.CSharpExpressions)](https://www.nuget.org/packages/BddDotNet.Gherkin.CSharpExpressions) |

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
4) Done. You can add gherkin feature files with test scenarios. Example `CheckoutForm.feature`:
```gherkin
Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to 'https://getbootstrap.com/docs/4.3/examples/checkout/'
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

# How to make C# expressions and json data from resources available in gherkin feature files

1) Install `BddDotNet.Gherkin.CSharpExpressions` nuget package
2) Add service for avaiable C# expressions
```csharp
using AutoTests.Framework.Resources;

namespace Bootstrap.Tests;

public sealed class CSharpExpressions(IDynamicDataService dynamicDataService)
{
    public dynamic Data { get; } = dynamicDataService.Data;
}
```
3) Configure `BddDotNet.Gherkin.CSharpExpressions` in `Program.cs`
```csharp
services.CSharpExpressions<CSharpExpressions>(ScriptOptions.Default.AddReferences("Microsoft.CSharp"));
services.DynamicResourcesData([Assembly.GetExecutingAssembly()]);
```

4) Now You can create json file in `Data` subfolder and get access to content in feature to it like:
```gherkin
Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl' #return value HomePageUrl from Data\Common.json
```
You can find example in 'Bootstrap.Tests'

# How to make custom component

You can create custom components with any custom logic. Example of button component:

```csharp
using AutoTests.Framework.Contracts;
using AutoTests.Framework.Options;
using AutoTests.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace AutoTests.Framework.Playwright;

public sealed class Button([ServiceKey] string path, IOptionsService optionsService, IPage page) : IComponent, IClick
{
    private readonly string locator = optionsService.GetOptions<string>(path);

    public async Task ClickAsync()
    {
        await page.ClickAsync(locator);
    }
}
```

Example of step with components:
```csharp
using AutoTests.Framework.Routing;

namespace Demo;

internal sealed class Steps(IRoutingService routingService)
{
    [When("click on '(.*)'")]
    public async Task ClickStep(string path)
    {
        await routingService.GetComponent<IClick>(path).ClickAsync();
    }
}
```

Components:
1) [required] Should implement IComponent interface
2) [required] Should implement contract interfaces like IClick, IVisible, e.t.c
3) [optional] Could reqeust options from `IOptionsService` using `[ServiceKey] string path` as a path for current component. Use can use it for example for locators
4) [optional Could inject any other custom services. In this example `IPage` is a Playwright service for browser control.



You can find example in 'AutoTests.Framework.Playwright' for default components like button, input, e.t.c







