namespace LearningManagement.Occupation.Application.EducationFields.Dtos.Get;

public sealed record EducationFieldSearchRequest(
    string? Title,
    long? Code,
    string? Description
);