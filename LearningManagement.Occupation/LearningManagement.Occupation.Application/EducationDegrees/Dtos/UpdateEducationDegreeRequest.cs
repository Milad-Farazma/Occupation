namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public record UpdateEducationDegreeRequest(
    string? Title,
    long Code,
    string? Description
);