# Sets up build environment

Write-Output "***** Create dotnet manifest (.config) *****"
& .\dotnet-manifest-setup.ps1
Write-Output ""

Write-Output "***** Get latest nuget.exe *****"
& .\nuget-dl.ps1
Write-Output ""