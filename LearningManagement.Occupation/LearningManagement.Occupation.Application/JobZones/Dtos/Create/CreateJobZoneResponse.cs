namespace LearningManagement.Occupation.Application.JobZones.Dtos.Create;

public record CreateJobZoneResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);