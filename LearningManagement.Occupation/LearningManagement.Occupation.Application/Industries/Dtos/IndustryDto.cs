namespace LearningManagement.Occupation.Application.Industries.Dtos;

public record IndustryDto(
    long Id,
    string? Title,
    long Code,
    string? Description);