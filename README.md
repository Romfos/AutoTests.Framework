# Owerview

SpecFlow based autotest framework

[![.github/workflows/test.yml](https://github.com/Romfos/AutoTests.Framework/actions/workflows/test.yml/badge.svg)](https://github.com/Romfos/AutoTests.Framework/actions/workflows/test.yml)

Main features:
- C# expression support inside features
- Test data management framework
- Model transformation framework
- Component framework for UI testing

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
- .NET 6+ (recommended) or .NET Standard 2.0 for older runtimes
- Visual Studio 2019, 2022 (recommended)
- Specflow plugin for Visual Studio

# Nuget packages links  
- https://www.nuget.org/packages/AutoTests.Framework
- https://www.nuget.org/packages/AutoTests.Framework.Components
- https://www.nuget.org/packages/AutoTests.Framework.Playwright

# How to use
You can find example in Boostrap.Tests project for UI testing

Basic steps:
1) Create unit test project
2) Add additional Specflow nuget packages for unit test provider:

| Unit test framework | Nuget package                                                     |
| ------------------- | ----------------------------------------------------------------- |
| MSTest              | [SpecFlow.MsTest](https://www.nuget.org/packages/SpecFlow.MsTest) |
| NUnit               | [SpecFlow.NUnit](https://www.nuget.org/packages/SpecFlow.NUnit)   |
| xUnit               | [SpecFlow.xUnit](https://www.nuget.org/profiles/specflow)         |
   
3) Add nuget package

[AutoTests.Framework.Playwright](https://www.nuget.org/packages/AutoTests.Framework.Playwright)

4) Create `specflow.json` and register framework assemblies. Example:
```
{
  "$schema": "https://specflow.org/specflow-config.json",
  "stepAssemblies": [
    { "assembly": "AutoTests.Framework" },
    { "assembly": "AutoTests.Framework.Components" },
    { "assembly": "AutoTests.Framework.Playwright" }
  ]
}
```
5) Create Application class for UI application

```csharp
internal sealed class BootstrapApplication : IApplication
{
    [Route("checkout")]
    public Checkout? Checkout { get; set; }
}
```

# How to make browser window visible
By default browser will run in headless mode.

If you need to change this behaviour just add BeforeTestRun hook inside your test app and override BrowserTypeLaunchOptions like this:
```csharp
[Binding]
internal sealed class SpecflowHooks
{
    [BeforeTestRun(Order = 0)]
    public static void BeforeTestRun(IObjectContainer objectContainer)
    {
        objectContainer.RegisterInstanceAs(new BrowserTypeLaunchOptions { Headless = false });
    }
}
```

# How to work with test data

You can create json file in Data subfolder and get access to content in feature to it like:
```gherkin
Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl' #return value HomePageUrl from Data\Common.json
```
You can find example in 'Boostrap.Tests'


