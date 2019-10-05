del *.nupkg
call pack.bat
set /p KEY=<credentials.txt
dotnet nuget push *.nupkg -k %KEY% -s https://api.nuget.org/v3/index.json