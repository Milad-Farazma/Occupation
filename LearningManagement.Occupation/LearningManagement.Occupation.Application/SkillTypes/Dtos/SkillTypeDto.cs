namespace LearningManagement.Occupation.Application.SkillTypes.Dtos;

public record SkillTypeDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<SkillTypeDto.SkillResponse> Skills) {
    public record SkillResponse(string? Title, long Code, string? Description);
}