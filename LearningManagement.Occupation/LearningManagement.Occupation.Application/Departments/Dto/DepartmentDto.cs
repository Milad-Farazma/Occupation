namespace LearningManagement.Occupation.Application.Departments.Dto;

public record DepartmentDto(
    long Id,
    long TypeId,
    string Title,
    long OrganizationId
);