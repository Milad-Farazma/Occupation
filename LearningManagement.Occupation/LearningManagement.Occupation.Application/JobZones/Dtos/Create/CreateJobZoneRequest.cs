namespace LearningManagement.Occupation.Application.JobZones.Dtos.Create;

public record CreateJobZoneRequest(
    string? Title,
    long Code,
    string? Description
);