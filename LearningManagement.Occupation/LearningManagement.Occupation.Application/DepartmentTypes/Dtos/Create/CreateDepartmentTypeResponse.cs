namespace LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Create;

public record CreateDepartmentTypeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);