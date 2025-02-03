namespace LearningManagement.Occupation.Application.SkillTypes.Dtos;

public record CreateSkillTypeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);