namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public record EducationDegreeDto(
    long Id,
    string? Title,
    long Code,
    string? Description);