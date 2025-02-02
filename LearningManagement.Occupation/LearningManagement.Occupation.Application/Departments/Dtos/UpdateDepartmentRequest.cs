namespace LearningManagement.Occupation.Application.Departments.Dtos;

public record UpdateDepartmentRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null,
    string? Address = null,
    string? Phone = null,
    string? Fax = null,
    string? WebSiteUrl = null,
    string? Email = null,
    int? OrganizationId = null,
    int? DepartmentTypeId = null,
    int? EducationCenterId = null
);