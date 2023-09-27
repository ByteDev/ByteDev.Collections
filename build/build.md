# Build Notes

## Build Files Summary

- `build.cake` - Defines the cake build steps.
- `build.ps1` - Runs the `build.cake` file.
- `ByteDev.Collections.nuspec` - NuGet nuspec file for the package.
- `ByteDev.Utilities.cake` - Utility functions to use from the `build.cake` file.
- `clean-tools.ps1` - Delete everything in the `tools` directory except `nuget.exe`.
- `dotnet-manifest-setup.ps1` - Setup the `.config\dotnet-tools.json` manifest. This JSON config file should be committed in the repo.
- `nuget-dl.ps1` - Download the latest `nuget.exe` to the `tools` directory.
- `nuget-publish.ps1` - Use to publish a package to nuget.org from local machine.
- `nuspec-check.ps1` - Does a compare between a nuspec file and its `.csproj` file to check package references are not missing from the nuspec file.

## Running a Build

From Powershell for first ever run:

1. If the git repo does not have a `\build\.config` directory with `dotnet-tools.json` manifest file then 
	- Run: `dotnet-manifest-setup.ps1`
2. Run `.\nuget-dl.ps1`
3. Run `.\build.ps1`

Subsequent builds can be performed by running just `.\build.ps1`

## AppVeyor CI

CI builds on the internet are run in [AppVeyor](https://www.appveyor.com/).

The `appveyor.yml` in the root of the git repo contains details on the image to use and steps etc.