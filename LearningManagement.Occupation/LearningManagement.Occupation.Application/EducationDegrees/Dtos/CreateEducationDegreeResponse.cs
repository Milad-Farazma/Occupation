namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public record CreateEducationDegreeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);