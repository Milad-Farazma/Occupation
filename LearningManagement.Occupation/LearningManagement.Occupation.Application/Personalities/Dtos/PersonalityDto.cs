namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public record PersonalityDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description);