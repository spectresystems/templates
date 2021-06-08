Write-Host "Uninstalling template..."
dotnet new -u Spectre.Templates

Remove-Item bin -Recurse
Remove-Item obj -Recurse
dotnet pack --force

Write-Host "Installing template..."
dotnet new -i .\bin\Debug\Spectre.Templates.0.3.0.nupkg