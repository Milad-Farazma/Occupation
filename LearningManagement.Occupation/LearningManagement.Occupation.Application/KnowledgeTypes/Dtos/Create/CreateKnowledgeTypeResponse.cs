namespace LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Create;

public record CreateKnowledgeTypeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);