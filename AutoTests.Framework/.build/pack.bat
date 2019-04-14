set /p Version=<Version.txt
dotnet pack ..\AutoTests.Framework.Core\AutoTests.Framework.Core.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PageObjects\AutoTests.Framework.PageObjects.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PageObjects.Contracts\AutoTests.Framework.PageObjects.Contracts.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PageObjects.Provider\AutoTests.Framework.PageObjects.Provider.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PreProcessor\AutoTests.Framework.PreProcessor.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.PreProcessor.Roslyn\AutoTests.Framework.PreProcessor.Roslyn.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.Models\AutoTests.Framework.Models.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"
dotnet pack ..\AutoTests.Framework.Configuration\AutoTests.Framework.Configuration.csproj -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"