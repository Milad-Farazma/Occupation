namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public record CreatePersonalityResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);