#!/bin/bash

# Function to display usage information
usage() {
  echo "Usage: $(basename "$0") <migration-name>"
  exit 1
}

# Check if dotnet CLI is installed
if ! command -v dotnet &> /dev/null; then
  echo "Error: 'dotnet' is not installed. Please install the .NET SDK to continue."
  exit 1
fi

# Check if dotnet ef tool is installed
if ! dotnet tool list -g | grep -q "dotnet-ef"; then
  echo "Error: 'dotnet-ef' tool is not installed. Install it globally with:"
  echo "  dotnet tool install --global dotnet-ef"
  exit 1
fi

# Check if migration name is provided
if [ -z "$1" ]; then
  echo "Error: Migration name is required."
  usage
fi

# Check if the migration name is valid (only alphanumeric and underscores)
name="$1"
if [[ ! "$name" =~ ^[a-zA-Z0-9_]+$ ]]; then
  echo "Error: Migration name must contain only alphanumeric characters or underscores."
  usage
fi

# Define project paths
project="LearningManagement.Occupation.Infrastructure"
startup_project="LearningManagement.Occupation.WebAPI"

# Check if project directories exist
if [ ! -d "$project" ]; then
  echo "Error: Project directory '$project' does not exist."
  exit 1
fi

if [ ! -d "$startup_project" ]; then
  echo "Error: Startup project directory '$startup_project' does not exist."
  exit 1
fi

# Add migration
echo "Adding migration '$name'..."
dotnet ef migrations add "$name" --project "$project" --startup-project "$startup_project" --output-dir Shared/Data/Migrations

# Check for success
if [ $? -eq 0 ]; then
  echo "Migration '$name' added successfully."
else
  echo "Error: Failed to add migration '$name'."
  exit 1
fi
