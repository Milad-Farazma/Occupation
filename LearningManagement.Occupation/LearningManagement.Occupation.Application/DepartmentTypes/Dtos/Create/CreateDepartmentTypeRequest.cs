namespace LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Create;

public record CreateDepartmentTypeRequest(
    string? Title,
    long Code,
    string? Description
);