# Owerview

SpecFlow based autotest framework

Main features:
- Pre Processor framework (allow to use C# expressions in specflow scenarios)
- Component framework (in primamry it is used for integration with other UI frameworks like Selenium WebDriver)
- Test data management framework

# Use requirements
- .NET Standart 2.0
- Visual Studio 2017, 2019
- Specflow plugin for Visual Studio

# Development requirements
- .NET Core 3
- Visual Studio 2019
- Specflow plugin for Visual Studio

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

Or you can reference all of them:  
- https://www.nuget.org/packages/AutoTests.Framework.All

# How to use
You can find example in Boostrap.Tests project  

Basic steps:
1) Create and configure basic specflow project
2) Add AutoTests.Framework.All nuget package
3) Register container in specflow hooks (you can find example in test project)
...  
Profit

