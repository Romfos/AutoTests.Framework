# Owerview

SpecFlow based autotest framework

Main features:
- Pre Processor framework (allow to use C# expressions in specflow scenarios)
- Component framework (in primamry it is used for integration with other UI frameworks like Selenium WebDriver)
- Test data management framework
- Model transformation framework

# Use requirements
- .NET Standart 2.0
- Visual Studio 2017, 2019
- Specflow plugin for Visual Studio

# Development requirements
- .NET Core 3
- Visual Studio 2019
- Specflow plugin for Visual Studio
- Google Chrome

# Nuget packages links  
You can reference required packages:  
- https://www.nuget.org/packages/AutoTests.Framework.Core
- https://www.nuget.org/packages/AutoTests.Framework.Core.Specflow
- https://www.nuget.org/packages/AutoTests.Framework.Components
- https://www.nuget.org/packages/AutoTests.Framework.Components.Routes
- https://www.nuget.org/packages/AutoTests.Framework.Components.Specflow
- https://www.nuget.org/packages/AutoTests.Framework.Data
- https://www.nuget.org/packages/AutoTests.Framework.PreProcessor
- https://www.nuget.org/packages/AutoTests.Framework.PreProcessor.Roslyn
- https://www.nuget.org/packages/AutoTests.Framework.PreProcessor.Specflow
- https://www.nuget.org/packages/AutoTests.Framework.Models
- https://www.nuget.org/packages/AutoTests.Framework.Models.Specflow

Or you can reference all of them:  
- https://www.nuget.org/packages/AutoTests.Framework.All

# How to use
You can find example in Boostrap.Tests project  

Basic steps:
1) Create unit test project
2) Add [AutoTests.Framework.All](https://www.nuget.org/packages/AutoTests.Framework.All) nuget package
3) Add additional Specflow nuget packages for unit test provider:

 - MSTest:  
   [SpecFlow.MsTest](https://www.nuget.org/packages/SpecFlow.MsTest)  
   [SpecFlow.Tools.MsBuild.Generation](https://www.nuget.org/packages/SpecFlow.Tools.MsBuild.Generation)

 - NUnit:  
   [SpecFlow.NUnit](https://www.nuget.org/packages/SpecFlow.NUnit)
4) Configure AutoTests app in Specflow hooks (you can find example in Boostrap.Tests)
