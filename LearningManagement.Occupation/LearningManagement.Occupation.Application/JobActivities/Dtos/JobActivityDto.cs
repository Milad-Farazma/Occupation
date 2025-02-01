namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public record JobActivityDto(
    long Id,
    string? Title,
    long Code,
    string? Description);