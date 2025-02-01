namespace LearningManagement.Occupation.Application.Skills.Dtos;

public record CreateSkillRequest(
    string? Title,
    long Code,
    string? Description
);