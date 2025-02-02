namespace LearningManagement.Occupation.Application.DepartmentTypes.Dtos;

public record UpdateDepartmentTypeRequest(
    string? Title,
    long Code,
    string? Description
);