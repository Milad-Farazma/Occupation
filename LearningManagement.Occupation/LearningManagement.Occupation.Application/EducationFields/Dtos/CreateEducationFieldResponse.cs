namespace LearningManagement.Occupation.Application.EducationFields.Dtos;

public record CreateEducationFieldResponse(
    long Id,
    string Title,
    long Code,
    string Description
);