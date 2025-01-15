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
$project = "LearningManagement.Occupation.Infrastructure"
$startup_project = "LearningManagement.Occupation.WebAPI"

# Check if project directories exist
if (-not (Test-Path $project)) {
    Write-Host "Error: Project directory '$project' does not exist."
    exit 1
}

if (-not (Test-Path $startup_project)) {
    Write-Host "Error: Startup project directory '$startup_project' does not exist."
    exit 1
}

# Remove migration
dotnet ef migrations remove --project $project --startup-project $startup_project

# Check for success
if ($LASTEXITCODE -eq 0) {
    Write-Host "Migration removed successfully."
} else {
    Write-Host "Error: Failed to remove migration."
    exit 1
}
