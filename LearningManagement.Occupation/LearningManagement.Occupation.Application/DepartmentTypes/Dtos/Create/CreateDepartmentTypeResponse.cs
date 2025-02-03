namespace LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Create;

public record CreateDepartmentTypeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);