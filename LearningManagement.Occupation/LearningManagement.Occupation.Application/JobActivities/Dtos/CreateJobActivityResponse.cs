namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public record CreateJobActivityResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);