namespace LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Create;

public record CreateKnowledgeTypeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);