set /p Version=<Version.txt
dotnet pack ..\AutoTests.Framework.Core\AutoTests.Framework.Core.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.Core.Specflow\AutoTests.Framework.Core.Specflow.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PreProcessor\AutoTests.Framework.PreProcessor.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PreProcessor.Roslyn\AutoTests.Framework.PreProcessor.Roslyn.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PreProcessor.Specflow\AutoTests.Framework.PreProcessor.Specflow.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.Components\AutoTests.Framework.Components.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.Components.Routes\AutoTests.Framework.Components.Routes.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.Components.Specflow\AutoTests.Framework.Components.Specflow.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"