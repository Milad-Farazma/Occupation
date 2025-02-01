namespace LearningManagement.Occupation.Application.SkillTypes.Dtos;

public sealed record SkillTypeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);