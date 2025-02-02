namespace LearningManagement.Occupation.Application.KnowledgeTypes.Dtos;

public record UpdateKnowledgeTypeRequest(
    string? Title,
    long Code,
    string? Description
);