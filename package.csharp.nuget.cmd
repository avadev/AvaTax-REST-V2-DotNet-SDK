@echo off
pushd .

ECHO ********** Packaging NUGET
cd src
..\..\..\nuget.exe pack Avalara.AvaTax.RestClient.nuspec
popd
pause