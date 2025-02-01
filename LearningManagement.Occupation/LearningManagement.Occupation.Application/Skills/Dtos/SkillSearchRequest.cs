namespace LearningManagement.Occupation.Application.Skills.Dtos;

public sealed record SkillSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);