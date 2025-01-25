namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

public record UpdateEducationFieldSpecializationRequest(
    string? Title,
    long Code,
    string? Description
);