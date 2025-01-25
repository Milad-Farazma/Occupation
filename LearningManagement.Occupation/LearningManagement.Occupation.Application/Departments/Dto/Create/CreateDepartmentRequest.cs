namespace LearningManagement.Occupation.Application.Departments.Dto.Create;

public record CreateDepartmentRequest(
    long TypeId,
    string Title,
    long OrganizationId
);