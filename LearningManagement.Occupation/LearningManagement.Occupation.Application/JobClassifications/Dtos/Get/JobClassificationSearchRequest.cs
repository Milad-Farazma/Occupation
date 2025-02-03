namespace LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;

public sealed record JobClassificationSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);