namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

public record CreateEducationFieldSpecializationRequest(
    string? Title,
    long Code,
    string? Description
);