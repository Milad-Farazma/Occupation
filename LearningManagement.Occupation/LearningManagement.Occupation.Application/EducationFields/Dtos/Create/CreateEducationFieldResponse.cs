namespace LearningManagement.Occupation.Application.EducationFields.Dtos.Create;

public record CreateEducationFieldResponse(
    long Id,
    string Title,
    long Code,
    string Description
);