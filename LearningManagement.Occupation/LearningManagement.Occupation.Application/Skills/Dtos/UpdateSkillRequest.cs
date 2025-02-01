namespace LearningManagement.Occupation.Application.Skills.Dtos;

public record UpdateSkillRequest(
    string? Title,
    long Code,
    string? Description
);