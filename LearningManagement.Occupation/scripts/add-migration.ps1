# Function to display usage information
function Show-Usage {
    Write-Host "Usage: $(Get-Command $MyInvocation.MyCommand).Name <migration-name>"
    exit 1
}

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

# Check if migration name is provided
if (-not $args[0]) {
    Write-Host "Error: Migration name is required."
    Show-Usage
}

# Check if the migration name is valid (only alphanumeric and underscores)
$name = $args[0]
if ($name -notmatch "^[a-zA-Z0-9_]+$") {
    Write-Host "Error: Migration name must contain only alphanumeric characters or underscores."
    Show-Usage
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

# Add migration
Write-Host "Adding migration '$name'..."
dotnet ef migrations add $name --project $project --startup-project $startup_project --output-dir Shared/Data/Migrations

# Check for success
if ($LASTEXITCODE -eq 0) {
    Write-Host "Migration '$name' added successfully."
} else {
    Write-Host "Error: Failed to add migration '$name'."
    exit 1
}
