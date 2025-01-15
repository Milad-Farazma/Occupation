#!/bin/bash

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

# Define project paths
project="LMS.Aquamation.Infrastructure"
startup_project="LMS.Aquamation.WebAPI"

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
dotnet ef migrations remove --project $project --startup-project $startup_project

# Check for success
if [ $? -eq 0 ]; then
  echo "MIgration removed successfully."
else
  echo "Error: Failed to remove migration."
  exit 1
fi
