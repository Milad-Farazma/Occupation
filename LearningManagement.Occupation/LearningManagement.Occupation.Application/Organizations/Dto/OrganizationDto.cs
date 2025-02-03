namespace LearningManagement.Occupation.Application.Organizations.Dto;

public record OrganizationDto(
    Guid Id,
    string? Title,
    long Code,
    int ProvinceId,
    string ProvinceTitle,
    int CityId,
    string CityTitle,
    Guid OrganTypeId,
    string? CertificateCode,
    string? WebsiteUrl,
    string? Email,
    string? LogoImg,
    string? Description,
    bool Accepted,
    DateOnly? AcceptedDate,
    int? AcceptedUserId,
    bool IsPublic,
    ICollection<OrganizationDto.DepartmentResponse> Departments,
    OrganizationDto.OrganizationTypeResponse OrganizationType) {
    public record DepartmentResponse(Guid Id, string Title);

    public record OrganizationTypeResponse(
        Guid Id,
        string? Title,
        long Code,
        string? Description);
}