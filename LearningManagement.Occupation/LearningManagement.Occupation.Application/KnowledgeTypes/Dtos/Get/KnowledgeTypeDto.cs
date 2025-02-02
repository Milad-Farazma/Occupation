namespace LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;

public record KnowledgeTypeDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<KnowledgeTypeDto.KnowledgeResponse> Knowledges) {
    public record KnowledgeResponse(string? Title, long Code, string? Description);
}