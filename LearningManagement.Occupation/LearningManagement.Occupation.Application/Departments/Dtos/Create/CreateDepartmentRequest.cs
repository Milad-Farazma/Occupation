namespace LearningManagement.Occupation.Application.Departments.Dtos.Create;

public record CreateDepartmentRequest(
    string? Title,
    long Code,
    string? Description,
    string? Address,
    string? Phone,
    string? Fax,
    string? WebSiteUrl,
    string? Email,
    Guid OrganizationId,
    Guid DepartmentTypeId,
    Guid? EducationCenterId
);