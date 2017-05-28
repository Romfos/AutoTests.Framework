del *.nupkg
call rebuild.bat
call assembly.bat
set /p KEY=<credentials.txt
nuget push *.nupkg %KEY% -Source https://www.nuget.org/api/v2/package