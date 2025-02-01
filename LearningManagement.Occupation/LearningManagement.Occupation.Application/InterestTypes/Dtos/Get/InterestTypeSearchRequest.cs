namespace LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;

public sealed record InterestTypeSearchRequest(
    string? Title = null,
    string? Description = null
);