namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public record CreatePersonalityRequest(
    string? Title,
    long Code,
    string? Description
);