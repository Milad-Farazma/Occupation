namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public record EducationDegreeDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description);