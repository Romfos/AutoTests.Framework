set /p Version=<Version.txt
dotnet pack ..\AutoTests.Framework.sln -p:Configuration=Release -p:PackageVersion=%Version% -p:version=%Version% -o "../.build"