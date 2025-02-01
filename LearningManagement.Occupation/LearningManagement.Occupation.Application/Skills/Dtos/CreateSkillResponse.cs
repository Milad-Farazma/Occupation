namespace LearningManagement.Occupation.Application.Skills.Dtos;

public record CreateSkillResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);