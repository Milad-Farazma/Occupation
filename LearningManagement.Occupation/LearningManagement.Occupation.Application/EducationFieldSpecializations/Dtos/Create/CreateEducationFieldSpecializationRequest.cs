namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Create;

public record CreateEducationFieldSpecializationRequest(
    string? Title,
    long Code,
    string? Description
);