namespace LearningManagement.Occupation.Application.Skills.Dtos;

public record CreateSkillResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    Guid SkillTypeId
);