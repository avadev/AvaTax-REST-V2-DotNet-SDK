@echo off
pushd .

ECHO ********** Build projects in release mode
dotnet build -p:BuildProjectReferences=false;DebugSymbols=false;AssemblyName=Avalara.AvaTax.RestClient -c Release --no-dependencies src\Avalara.AvaTax.RestClient.csproj

ECHO ********** Packaging NUGET
.\nuget.exe pack src\Avalara.AvaTax.RestClient.nuspec
pause