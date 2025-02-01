namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public record CreateJobActivityRequest(
    string? Title,
    long Code,
    string? Description
);