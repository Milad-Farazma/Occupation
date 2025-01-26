namespace LearningManagement.Occupation.Application.Departments.Dto.Update;

public record UpdateDepartmentRequest(
    string Title,
    long OrganizationId
);