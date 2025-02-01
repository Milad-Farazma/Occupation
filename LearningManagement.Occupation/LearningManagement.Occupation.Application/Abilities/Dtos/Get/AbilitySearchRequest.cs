namespace LearningManagement.Occupation.Application.Abilities.Dtos.Get;

public sealed record AbilitySearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);