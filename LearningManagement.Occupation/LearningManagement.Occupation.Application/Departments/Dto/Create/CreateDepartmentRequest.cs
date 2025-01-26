namespace LearningManagement.Occupation.Application.Departments.Dto.Create;

public record CreateDepartmentRequest(
    string Title,
    long OrganizationId
);