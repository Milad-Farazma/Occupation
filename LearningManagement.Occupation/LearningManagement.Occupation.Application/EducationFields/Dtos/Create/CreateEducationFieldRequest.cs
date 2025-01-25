namespace LearningManagement.Occupation.Application.EducationFields.Dtos.Create;

public record CreateEducationFieldRequest(
    string Title,
    long Code,
    string Description
);