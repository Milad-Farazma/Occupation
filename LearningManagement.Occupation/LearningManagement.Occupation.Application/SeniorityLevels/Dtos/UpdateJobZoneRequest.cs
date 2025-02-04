namespace LearningManagement.Occupation.Application.SeniorityLevels.Dtos;

public record UpdateSeniorityLevelRequest(
    string? Title,
    long Code,
    string? Description
);