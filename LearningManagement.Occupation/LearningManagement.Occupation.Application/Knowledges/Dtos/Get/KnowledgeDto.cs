namespace LearningManagement.Occupation.Application.Knowledges.Dtos.Get;

public record KnowledgeDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    KnowledgeDto.KnowledgeTypeResponse KnowledgeType) {
    public record KnowledgeTypeResponse(string? Title, long Code, string? Description);
}