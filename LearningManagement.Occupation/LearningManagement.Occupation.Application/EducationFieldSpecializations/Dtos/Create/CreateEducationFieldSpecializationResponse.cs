namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Create;

public record CreateEducationFieldSpecializationResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);