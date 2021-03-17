Push-Location ## https://msdn.microsoft.com/en-us/powershell/reference/3.0/microsoft.powershell.management/push-location

$nugetUrl = "https://dist.nuget.org/win-x86-commandline/v3.5.0/nuget.exe";

if (-not (Test-Path .\nuget.exe)) {

    Write-Host "Downloading Nuget.exe from $nugetUrl"
    Invoke-WebRequest -Uri $nugetUrl -OutFile nuget.exe
}

Write-Host ""
Write-Host "********** Build projects in release mode"
Write-Host ""

function Build-Solution { 
    param ( [string]$solution)

    & '.\nuget.exe' 'restore' $solution
    & 'C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe' $solution '/t:Build' '/p:Configuration="Release"'
}


Build-Solution -solution 'Avalara.AvaTax.Net20.sln'
Build-Solution -solution 'Avalara.AvaTax.Net45.sln'
Build-Solution -solution 'Avalara.AvaTax.Net461.sln'
Build-Solution -solution 'Avalara.AvaTax.netstandard20.sln'
Build-Solution -solution 'Avalara.AvaTax.Portable.sln'


Write-Host ""
Write-Host "********** Packaging NUGET"

& '.\nuget.exe' 'pack' '.\src\Avalara.AvaTax.nuspec'


Pop-Location ## https://msdn.microsoft.com/en-us/powershell/reference/3.0/microsoft.powershell.management/pop-location