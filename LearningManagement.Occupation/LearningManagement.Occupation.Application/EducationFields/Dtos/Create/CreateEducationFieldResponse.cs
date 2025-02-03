namespace LearningManagement.Occupation.Application.EducationFields.Dtos.Create;

public record CreateEducationFieldResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);