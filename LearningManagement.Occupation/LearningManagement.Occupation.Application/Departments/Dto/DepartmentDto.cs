namespace LearningManagement.Occupation.Application.Departments.Dto;

public record DepartmentDto(
    long Id,
    string Title,
    DepartmentDto.OrganizationDto Organization
) {
    public record OrganizationDto(
        long Id,
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
        bool IsPublic
    );
}