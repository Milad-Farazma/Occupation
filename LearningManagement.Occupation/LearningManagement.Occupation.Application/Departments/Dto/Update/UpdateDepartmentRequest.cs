namespace LearningManagement.Occupation.Application.Departments.Dto.Update;

public record UpdateDepartmentRequest(
    long TypeId,
    string Title,
    long OrganizationId
);