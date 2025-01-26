namespace LearningManagement.Occupation.Application.Departments.Dtos;

public record CreateDepartmentRequest(
    string Title,
    long OrganizationId
);