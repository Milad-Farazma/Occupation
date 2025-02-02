namespace LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Create;

public record CreateKnowledgeTypeRequest(
    string? Title,
    long Code,
    string? Description
);