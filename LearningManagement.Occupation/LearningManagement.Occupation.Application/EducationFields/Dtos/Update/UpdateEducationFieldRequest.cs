namespace LearningManagement.Occupation.Application.EducationFields.Dtos.Update;

public record UpdateEducationFieldRequest(
    string Title,
    long Code,
    string Description
);