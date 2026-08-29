$ErrorActionPreference = "Stop"

$DataProject = "Portfolio.Data"
$StartupProject = "Portfolio.Backend"
$Context = "AppDbContext"

Write-Host ""
Write-Host "=== Portfolio Database Migration ===" -ForegroundColor Cyan
Write-Host ""

# Check for model changes
Write-Host "Checking for model changes..."

dotnet ef migrations has-pending-model-changes `
    --project $DataProject `
    --startup-project $StartupProject `
    --context $Context

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to check for model changes."
    exit 1
}

# Create migration
$MigrationName = "Auto_$(Get-Date -Format 'yyyyMMdd_HHmmss')"

Write-Host ""
Write-Host "Creating migration: $MigrationName"

dotnet ef migrations add $MigrationName `
    --project $DataProject `
    --startup-project $StartupProject `
    --context $Context

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to create migration."
    exit 1
}

# Update database
Write-Host ""
Write-Host "Updating database..."

dotnet ef database update `
    --project $DataProject `
    --startup-project $StartupProject `
    --context $Context

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to update database."
    exit 1
}

Write-Host ""
Write-Host "=== Database updated successfully ===" -ForegroundColor Green
Write-Host ""