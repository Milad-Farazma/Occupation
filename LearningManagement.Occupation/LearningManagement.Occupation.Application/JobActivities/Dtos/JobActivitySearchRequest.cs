namespace LearningManagement.Occupation.Application.JobActivities.Dtos;

public sealed record JobActivitySearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);