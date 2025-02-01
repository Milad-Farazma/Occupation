namespace LearningManagement.Occupation.Application.Skills.Dtos;

public record SkillDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    SkillDto.SkillTypeResponse SkillType) {
    public record SkillTypeResponse(string? Title, long Code, string? Description);
}