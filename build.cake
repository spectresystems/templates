#addin nuget:?package=Cake.MinVer&version=2.0.0

////////////////////////////////////////////////////////////////
// Tasks

Task("Clean")
    .Does(ctx =>
{
    CleanDirectory("./.artifacts");
    CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
});

Task("Copy-Files")
    .IsDependentOn("Clean")
    .Does(ctx =>
{
    CopyFile("resources/CODE_OF_CONDUCT.md", "./templates/lib/CODE_OF_CONDUCT.md");
    CopyFile("resources/CODE_OF_CONDUCT.md", "./templates/cli/CODE_OF_CONDUCT.md");
    CopyFile("resources/default.gitignore", "./templates/lib/.gitignore");
    CopyFile("resources/default.gitignore", "./templates/cli/.gitignore");
    CopyFile("resources/Directory.Build.props", "./templates/lib/src/Directory.Build.props");
    CopyFile("resources/Directory.Build.props", "./templates/cli/src/Directory.Build.props");
    CopyFile("resources/Directory.Build.targets", "./templates/lib/src/Directory.Build.targets");
    CopyFile("resources/Directory.Build.targets", "./templates/cli/src/Directory.Build.targets");
    CopyFile("resources/dotnet-tools.json", "./templates/lib/dotnet-tools.json");
    CopyFile("resources/dotnet-tools.json", "./templates/cli/dotnet-tools.json");
    CopyFile("resources/global.json", "./templates/lib/global.json");
    CopyFile("resources/global.json", "./templates/cli/global.json");
    CopyFile("resources/LICENSE.md", "./templates/lib/LICENSE.md");
    CopyFile("resources/LICENSE.md", "./templates/cli/LICENSE.md");
    CopyFile("resources/root.editorconfig", "./templates/lib/.editorconfig");
    CopyFile("resources/root.editorconfig", "./templates/cli/.editorconfig");
    CopyFile("resources/source.editorconfig", "./templates/lib/src/.editorconfig");
    CopyFile("resources/source.editorconfig", "./templates/cli/src/.editorconfig");
    CopyFile("resources/test.editorconfig", "./templates/lib/src/TheProject.Tests/.editorconfig");
    CopyFile("resources/test.editorconfig", "./templates/cli/src/TheProject.Tests/.editorconfig");
});

Task("Pack")
    .IsDependentOn("Copy-Files")
    .Does(ctx =>
{
    DotNetPack("./Templates.csproj", new DotNetPackSettings {
        Configuration = "Release",
        OutputDirectory = "./.artifacts"
    });
});

Task("Uninstall")
    .ContinueOnError()
    .Does(ctx =>
{
    StartProcess("dotnet", "new -u SpectreSystems.Templates");
});

Task("Install")
    .IsDependentOn("Pack")
    .IsDependentOn("Uninstall")
    .Does(ctx =>
{
    // Get the version
    var minver = MinVer(new MinVerSettings {
        DefaultPreReleasePhase = "preview",
    });

    // Install
    StartProcess("dotnet", $"new -i ./.artifacts/SpectreSystems.Templates.{minver.Version}.nupkg");
});

////////////////////////////////////////////////////////////////
// Execution

RunTarget(Argument("target", "Pack"));