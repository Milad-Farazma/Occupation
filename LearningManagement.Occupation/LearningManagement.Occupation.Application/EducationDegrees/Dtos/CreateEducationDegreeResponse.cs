namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public record CreateEducationDegreeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);