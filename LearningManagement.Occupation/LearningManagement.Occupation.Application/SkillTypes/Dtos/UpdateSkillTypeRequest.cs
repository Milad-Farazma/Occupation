namespace LearningManagement.Occupation.Application.SkillTypes.Dtos;

public record UpdateSkillTypeRequest(
    string? Title,
    long Code,
    string? Description
);