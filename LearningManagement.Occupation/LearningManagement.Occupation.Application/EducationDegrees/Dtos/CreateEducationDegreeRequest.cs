namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public record CreateEducationDegreeRequest(
    string? Title,
    long Code,
    string? Description
);