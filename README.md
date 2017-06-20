# Owerview

AutoTests.Framework is plugin\extension for specflow.

Framework features:
- Automatic model transformations
- Model comparator
- PreProcessor
- Silenium WebDriver integration framework
- Test data managment

Tools:
- Additional tool for writhing refactroings (see AutoTests.Tools.Refactroings)

# Requirements
- .NET Framework 4.6
- Visual Studio 2017 (older version not tested, but maybe?)
- Specflow plugin for Visual Studio (for *.feature files highlighting)

# Links

- https://www.nuget.org/packages/AutoTests.Framework.Core
- https://www.nuget.org/packages/AutoTests.Framework.Models
- https://www.nuget.org/packages/AutoTests.Framework.PreProcessor
- https://www.nuget.org/packages/AutoTests.Framework.Web
- https://www.nuget.org/packages/AutoTests.Framework.TestData

Additional packages
- https://www.nuget.org/packages/AutoTests.Tools.Refactroings/

# How to use
1) Create and configure basic specflow project
2) Add nuget packages
3) Create application class (see example)
4) Regsiter and configure application class in [Before Scenario] method (see example)  
...  
Profit
