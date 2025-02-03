namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Create;

public record CreateEducationFieldSpecializationResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);