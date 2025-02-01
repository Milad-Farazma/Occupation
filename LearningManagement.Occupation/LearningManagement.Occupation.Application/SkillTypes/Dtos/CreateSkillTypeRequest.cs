namespace LearningManagement.Occupation.Application.SkillTypes.Dtos;

public record CreateSkillTypeRequest(
    string? Title,
    long Code,
    string? Description
);