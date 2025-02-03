namespace LearningManagement.Occupation.Application.Industries.Dtos;

public record IndustryDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description);