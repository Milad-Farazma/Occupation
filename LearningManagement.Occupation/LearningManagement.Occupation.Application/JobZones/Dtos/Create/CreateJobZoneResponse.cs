namespace LearningManagement.Occupation.Application.JobZones.Dtos.Create;

public record CreateJobZoneResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);