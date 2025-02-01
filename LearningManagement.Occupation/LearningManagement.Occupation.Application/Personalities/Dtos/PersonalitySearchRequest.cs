namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public sealed record PersonalitySearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);