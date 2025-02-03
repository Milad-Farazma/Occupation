namespace LearningManagement.Occupation.Application.JobZones.Dtos.Get;

public sealed record JobZoneSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);