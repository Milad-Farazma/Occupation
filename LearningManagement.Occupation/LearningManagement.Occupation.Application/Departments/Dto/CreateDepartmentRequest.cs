namespace LearningManagement.Occupation.Application.Departments.Dto;

public record CreateDepartmentRequest(
    long TypeId,
    string Title,
    long OrganizationId
);