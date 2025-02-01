namespace LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;

public sealed record AbilityTypeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);