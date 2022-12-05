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
    Then should have following values:
    | Name                              | Value                      |
    | checkout > username error message | Your username is required. |

```

# Requirements
- .NET 6 (recomended) or .NET Framework 4.6.2+ or .NET Standart 2.0 for other runtimes
- Visual Studio 2019, 2022
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
   
3) Add required nuget packages 

[AutoTests.Framework](https://www.nuget.org/packages/AutoTests.Framework) 
- [x] C# expressions in features support
- [x] Model transformations
- [x] Test data management
     
[AutoTests.Framework.Components](https://www.nuget.org/packages/AutoTests.Framework.Components)
- [x] Component framework for UI testing with Playwright\Selenium\e.t.c
     
[AutoTests.Framework.Playwright](https://www.nuget.org/packages/AutoTests.Framework.Playwright)
- [x] Playwright integration for UI testing with some basic components
     
4) Register framework packages in `specflow.json`. Example:
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

# How to run test not in headless mode (make browser visible)

Just add BeforeTestRun hook inside your test app and ovveride BrowserTypeLaunchOptions like this:
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

# Legacy 4.8.x version
- Source code: [AutoTests.Framework/tree/4.8.x](https://github.com/Romfos/AutoTests.Framework/tree/4.8.x)
- Readme: https://github.com/Romfos/AutoTests.Framework/blob/4.8.x/README.md
