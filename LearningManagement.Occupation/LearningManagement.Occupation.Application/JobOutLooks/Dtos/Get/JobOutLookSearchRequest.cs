namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;

public sealed record JobOutLookSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);