namespace LearningManagement.Occupation.Application.Departments.Dtos.Get;

public sealed record DepartmentSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null,
    string? Address = null,
    string? Phone = null,
    string? Fax = null,
    string? WebSiteUrl = null,
    string? Email = null
);