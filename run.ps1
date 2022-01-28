$date = Get-Date
$buildNumber = $date.ToString("yyyyMMdd.HHmm")

$adminPath = Join-Path $PSScriptRoot "\XtramileWeather"
$adminCsproj = Join-Path $adminPath "\XtramileWeather.App.csproj"
$clientApp = Join-Path $adminPath "\ClientApp"

# Start Admin
Write-Host "Running NPM process..." -ForegroundColor Yellow

Set-Location -Path $clientApp

npm install

npm run build-prod

Write-Host
Write-Host "Building Admin..." -ForegroundColor Yellow

Set-Location $PSScriptRoot

dotnet build $adminCsproj -p:InformationalVersion=$buildNumber

Write-Host
Write-Host "Running Admin..." -ForegroundColor Yellow

dotnet run --project $adminCsproj --no-build
