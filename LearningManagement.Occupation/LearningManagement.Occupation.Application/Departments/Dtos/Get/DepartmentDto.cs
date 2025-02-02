namespace LearningManagement.Occupation.Application.Departments.Dtos.Get;

public record DepartmentDto(
    long Id,
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
    int? EducationCenterId,
    DepartmentDto.DepartmentTypeResponse DepartmentType,
    DepartmentDto.OrganizationResponse Organization) {
    public record DepartmentTypeResponse(string? Title, long Code, string? Description);

    public record OrganizationResponse(
        string? Title,
        long Code,
        int ProvinceId,
        string ProvinceTitle,
        int CityId,
        string CityTitle,
        int OrganTypeId,
        string? CertificateCode,
        string? WebsiteUrl,
        string? Email,
        string? LogoImg,
        string? Description,
        bool Accepted,
        DateOnly? AcceptedDate,
        int? AcceptedUserId,
        bool IsPublic);
}