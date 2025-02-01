namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public record CreateJobActivityResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);