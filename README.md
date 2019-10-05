# Owerview

SpecFlow based autotest framework

Main features:
- Pre Processor framework (allow to use C# expressions in specflow scenarios)
- Component framework (in primamry it is used for integration with other UI frameworks like Selenium WebDriver)

# Use requirements
- .NET Standart 2.0
- Visual Studio 2017, 2019
- Specflow plugin for Visual Studio

# Development requirements
- .NET Core 3
- Visual Studio 2019
- Specflow plugin for Visual Studio

# Nuget packages links
Version 4:  
 // todo  
Version 3:
- https://www.nuget.org/packages/AutoTests.Framework.Core
- https://www.nuget.org/packages/AutoTests.Framework.Models
- https://www.nuget.org/packages/AutoTests.Framework.PageObjects
- https://www.nuget.org/packages/AutoTests.Framework.PageObjects.Contracts
- https://www.nuget.org/packages/AutoTests.Framework.PageObjects.Provider
- https://www.nuget.org/packages/AutoTests.Framework.PreProcessor
- https://www.nuget.org/packages/AutoTests.Framework.PreProcessor.Roslyn
- https://www.nuget.org/packages/AutoTests.Framework.Configuration

# How to use
1) Create and configure basic specflow project
2) Add AutoTests.Framework.* nuget packages
3) Register container in specflow hooks (you can find example in test project)
...  
Profit