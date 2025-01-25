namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

public sealed record EducationFieldSpecializationSearchRequest(
    string? Title,
    long? Code,
    string? Description
);