namespace LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Create;

public record CreateSeniorityLevelResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);