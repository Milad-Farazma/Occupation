namespace LearningManagement.Occupation.Application.Knowledges.Dtos.Get;

public sealed record KnowledgeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);