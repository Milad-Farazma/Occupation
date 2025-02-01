namespace LearningManagement.Occupation.Application.Personalities.Dtos;

public record PersonalityDto(
    long Id,
    string? Title,
    long Code,
    string? Description);