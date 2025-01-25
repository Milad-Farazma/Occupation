namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Update;

public record UpdateEducationFieldSpecializationRequest(
    string? Title,
    long Code,
    string? Description
);