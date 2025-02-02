namespace LearningManagement.Occupation.Application.Technologys.Dtos.Get;

public sealed record TechnologySearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);