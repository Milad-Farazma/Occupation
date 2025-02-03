namespace LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;

public record DepartmentTypeDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<DepartmentTypeDto.DepartmentResponse> Departments) {
    public record DepartmentResponse(
        Guid Id,
        string? Title,
        long Code,
        string? Description,
        string? Address,
        string? Phone,
        string? Fax,
        string? WebSiteUrl,
        string? Email);
}