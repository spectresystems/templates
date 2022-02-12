Write-Host "Uninstalling template..."
dotnet new -u SpectreSystems.Templates

Remove-Item bin -Recurse
Remove-Item obj -Recurse
dotnet pack --force

Write-Host "Installing template..."
dotnet new -i .\bin\Debug\SpectreSystems.Templates.0.4.0.nupkg