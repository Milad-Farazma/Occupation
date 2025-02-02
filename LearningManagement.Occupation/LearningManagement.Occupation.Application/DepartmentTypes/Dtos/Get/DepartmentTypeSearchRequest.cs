namespace LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;

public sealed record DepartmentTypeSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);