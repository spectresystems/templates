#!/opt/homebrew/bin/pwsh

Write-Host "Uninstalling template..."
dotnet new -u SpectreSystems.Templates

Remove-Item bin -Recurse
Remove-Item obj -Recurse
dotnet pack --force

Write-Host "Installing template..."
dotnet new install ./bin/Release/SpectreSystems.Templates.8.0.2-preview.0.1.nupkg