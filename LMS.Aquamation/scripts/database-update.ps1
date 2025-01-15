# Check if dotnet CLI is installed
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Host "Error: 'dotnet' is not installed. Please install the .NET SDK to continue."
    exit 1
}

# Check if dotnet ef tool is installed
if (-not (dotnet tool list -g | Select-String -Pattern "dotnet-ef")) {
    Write-Host "Error: 'dotnet-ef' tool is not installed. Install it globally with:"
    Write-Host "  dotnet tool install --global dotnet-ef"
    exit 1
}

# Define project paths
$project = "LMS.Aquamation.Infrastructure"
$startup_project = "LMS.Aquamation.WebAPI"

# Check if project directories exist
if (-not (Test-Path $project)) {
    Write-Host "Error: Project directory '$project' does not exist."
    exit 1
}

if (-not (Test-Path $startup_project)) {
    Write-Host "Error: Startup project directory '$startup_project' does not exist."
    exit 1
}

# Update database
dotnet ef database update --project $project --startup-project $startup_project

# Check for success
if ($LASTEXITCODE -eq 0) {
    Write-Host "Database updated successfully."
} else {
    Write-Host "Error: Failed to update database."
    exit 1
}
