namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public record JobActivityDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description);