namespace LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;

public sealed record TechnologyTypeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);