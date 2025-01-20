namespace LearningManagement.Occupation.Application.Departments.Dto;

public record UpdateDepartmentRequest(
    long TypeId,
    string Title,
    long OrganizationId
);