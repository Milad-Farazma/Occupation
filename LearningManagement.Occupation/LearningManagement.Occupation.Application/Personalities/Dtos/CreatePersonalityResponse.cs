namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public record CreatePersonalityResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);