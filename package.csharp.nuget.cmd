@echo off
pushd .

ECHO ********** Restore projects
dotnet restore Avalara.AvaTax.Net20.sln
dotnet restore Avalara.AvaTax.net45.sln
dotnet restore Avalara.AvaTax.netstandard11.sln

ECHO ********** Build projects in release mode
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" Avalara.AvaTax.Net20.sln /p:platform="Any CPU" /t:Build /p:Configuration="Release"
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" Avalara.AvaTax.net45.sln /p:platform="Any CPU" /t:Build /p:Configuration="Release"

dotnet build Avalara.AvaTax.netstandard11.sln -c Release

ECHO ********** Packaging NUGET
..\..\nuget.exe pack src\Avalara.AvaTax.nuspec
pause