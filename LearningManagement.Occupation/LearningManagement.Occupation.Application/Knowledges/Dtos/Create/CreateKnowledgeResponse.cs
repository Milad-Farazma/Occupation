namespace LearningManagement.Occupation.Application.Knowledges.Dtos.Create;

public record CreateKnowledgeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);