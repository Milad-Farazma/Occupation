namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Get;

public sealed record EducationFieldSpecializationSearchRequest(
    string? Title,
    long? Code,
    string? Description
);