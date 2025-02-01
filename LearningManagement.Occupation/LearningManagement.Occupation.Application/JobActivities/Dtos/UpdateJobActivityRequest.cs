namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public record UpdateJobActivityRequest(
    string? Title,
    long Code,
    string? Description
);