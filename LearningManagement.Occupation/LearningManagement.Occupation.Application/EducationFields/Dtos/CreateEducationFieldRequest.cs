namespace LearningManagement.Occupation.Application.EducationFields.Dtos;

public record CreateEducationFieldRequest(
    string Title,
    long Code,
    string Description
);