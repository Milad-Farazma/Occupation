namespace LearningManagement.Occupation.Application.EducationFields.Dtos;

public sealed record EducationFieldSearchRequest(
    string? Title,
    long? Code,
    string? Description
);