# Script to drop the database using EF Core CLI
param (
    [string]$StartupProject = "LearningManagement.Occupation.WebAPI",
    [string]$InfrastructureProject = "LearningManagement.Occupation.Infrastructure"
)

# Function to check if dotnet-ef CLI tool is installed
function Check-DotnetEF {
    $dotnetEfInstalled = dotnet tool list -g | Select-String "dotnet-ef"
    if (-not $dotnetEfInstalled) {
        Write-Host "dotnet-ef tool is not installed. Installing..."
        dotnet tool install --global dotnet-ef
        if ($?) {
            Write-Host "dotnet-ef installed successfully."
        } else {
            Write-Error "Failed to install dotnet-ef. Please install it manually."
            exit 1
        }
    } else {
        Write-Host "dotnet-ef is already installed."
    }
}

# Check if dotnet-ef is available
Check-DotnetEF

# Get the full path of the infrastructure project
$CurrentDirectory = Get-Location
$InfrastructureProjectPath = Join-Path -Path $CurrentDirectory -ChildPath $InfrastructureProject

# Drop the database
Write-Host "Dropping the database for startup project '$StartupProject'..."
dotnet ef database drop --project "$InfrastructureProjectPath" --startup-project "$StartupProject" --force

if ($?) {
    Write-Host "Database dropped successfully."
} else {
    Write-Error "Failed to drop the database."
    exit 1
}
