namespace LearningManagement.Occupation.Application.Knowledges.Dtos;

public record UpdateKnowledgeRequest(
    string? Title,
    long Code,
    string? Description
);