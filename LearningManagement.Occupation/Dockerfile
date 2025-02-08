# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

# Restore dependencies
RUN dotnet restore LearningManagement.Occupation.sln

# Build the solution in release mode
RUN dotnet build LearningManagement.Occupation.sln -c Release -o /app/build

FROM build AS publish
RUN dotnet publish LearningManagement.Occupation.WebAPI/LearningManagement.Occupation.WebAPI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningManagement.Occupation.WebAPI.dll"]
