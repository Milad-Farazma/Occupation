namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public record UpdatePersonalityRequest(
    string? Title,
    long Code,
    string? Description
);