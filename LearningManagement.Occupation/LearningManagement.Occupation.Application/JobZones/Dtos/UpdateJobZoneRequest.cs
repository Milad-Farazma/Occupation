namespace LearningManagement.Occupation.Application.JobZones.Dtos;

public record UpdateJobZoneRequest(
    string? Title,
    long Code,
    string? Description
);