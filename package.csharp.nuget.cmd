@echo off
pushd .

ECHO ********** Build projects in release mode
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" Avalara.AvaTax.Net20.sln /t:Build /p:Configuration="Release"
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" Avalara.AvaTax.Portable.sln /t:Build /p:Configuration="Release"

ECHO ********** Packaging NUGET
cd src
..\..\..\nuget.exe pack Avalara.AvaTax.nuspec
popd
pause