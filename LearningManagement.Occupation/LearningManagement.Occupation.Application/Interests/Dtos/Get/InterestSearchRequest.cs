namespace LearningManagement.Occupation.Application.Interests.Dtos.Get;

public sealed record InterestSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);