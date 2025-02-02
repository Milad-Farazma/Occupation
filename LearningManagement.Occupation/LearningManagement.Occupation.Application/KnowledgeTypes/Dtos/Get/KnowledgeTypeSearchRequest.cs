namespace LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;

public sealed record KnowledgeTypeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);