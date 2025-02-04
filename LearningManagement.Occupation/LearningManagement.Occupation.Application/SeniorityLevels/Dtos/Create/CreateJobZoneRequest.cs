namespace LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Create;

public record CreateSeniorityLevelRequest(
    string? Title,
    long Code,
    string? Description
);