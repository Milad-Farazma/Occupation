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
    int OrganizationId,
    int DepartmentTypeId,
    int? EducationCenterId
);