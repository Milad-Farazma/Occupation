namespace LearningManagement.Occupation.Application.Aliases.Dtos.Get;

public sealed record AliasSearchRequest(
    string? AlternativeTitle = null,
    Guid? OccupationId = null
);