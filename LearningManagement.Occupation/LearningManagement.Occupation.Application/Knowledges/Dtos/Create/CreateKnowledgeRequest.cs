namespace LearningManagement.Occupation.Application.Knowledges.Dtos.Create;

public record CreateKnowledgeRequest(
    string? Title,
    long Code,
    string? Description
);