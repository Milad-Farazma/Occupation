namespace LearningManagement.Occupation.Application.Departments.Dtos;

public record UpdateDepartmentRequest(
    long TypeId,
    string Title,
    long OrganizationId
);