namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

public record CreateEducationFieldSpecializationResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);