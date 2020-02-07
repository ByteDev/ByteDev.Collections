#addin nuget:?package=Cake.Incubator&version=5.1.0
#tool "nuget:?package=NUnit.Runners&version=2.7.1"
#tool "nuget:?package=GitVersion.CommandLine&version=5.0.1"
#load "ByteDev.Utilities.cake"

var solutionName = "ByteDev.Collections";
var projName = "ByteDev.Collections";

var solutionFilePath = "../" + solutionName + ".sln";
var nuspecFilePath = projName + ".nuspec";

var nugetSources = new[] {"https://api.nuget.org/v3/index.json"};

var target = Argument("target", "Default");

var artifactsDirectory = Directory("../artifacts");
var nugetDirectory = artifactsDirectory + Directory("NuGet");

var configuration = GetBuildConfiguration();

Information("Configurtion: " + configuration);


Task("Clean")
    .Does(() =>
	{
		CleanDirectory(artifactsDirectory);
	
		CleanBinDirectories();
		CleanObjDirectories();
	});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
		var settings = new NuGetRestoreSettings
		{
			Source = nugetSources
		};

		NuGetRestore(solutionFilePath, settings);
    });

Task("Build")
	.IsDependentOn("Restore")
    .Does(() =>
	{	
		var settings = new DotNetCoreBuildSettings()
        {
            Configuration = configuration
        };

        DotNetCoreBuild(solutionFilePath, settings);
	});

Task("UnitTests")
    .IsDependentOn("Build")
    .Does(() =>
	{
		var settings = new DotNetCoreTestSettings()
		{
			Configuration = configuration,
			NoBuild = true
		};

		DotNetCoreUnitTests(settings);
	});
	
Task("CreateNuGetPackages")
    .IsDependentOn("UnitTests")
    .Does(() =>
    {
		var nugetVersion = GetNuGetVersion();

		var nugetSettings = new NuGetPackSettings 
		{
			Version = nugetVersion,
			OutputDirectory = nugetDirectory
		};
                
		NuGetPack(nuspecFilePath, nugetSettings);
    });

   
Task("Default")
    .IsDependentOn("CreateNuGetPackages");

RunTarget(target);
