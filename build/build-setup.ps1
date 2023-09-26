Write-Output "Create manifest (.config)"
dotnet new tool-manifest
dotnet tool install Cake.Tool --version 3.0.0
& .\nuget-dl.ps1