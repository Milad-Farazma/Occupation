namespace LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;

public sealed record SeniorityLevelSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);