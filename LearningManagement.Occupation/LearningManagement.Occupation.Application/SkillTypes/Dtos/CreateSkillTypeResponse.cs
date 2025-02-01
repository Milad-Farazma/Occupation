namespace LearningManagement.Occupation.Application.SkillTypes.Dtos;

public record CreateSkillTypeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);