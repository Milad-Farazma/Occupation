namespace LearningManagement.Occupation.Application.EducationDegrees.Dtos;

public sealed record EducationDegreeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);