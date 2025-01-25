namespace LearningManagement.Occupation.Application.EducationFields.Dtos;

public record UpdateEducationFieldRequest(
    string Title,
    long Code,
    string Description
);