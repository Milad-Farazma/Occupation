namespace LearningManagement.Occupation.Application.Knowledges.Dtos.Create;

public record CreateKnowledgeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);