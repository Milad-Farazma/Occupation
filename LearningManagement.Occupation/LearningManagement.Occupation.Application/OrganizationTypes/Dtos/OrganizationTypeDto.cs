namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

public record OrganizationTypeDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<OrganizationTypeDto.OrgDto> Organizations) {
    public record OrgDto(
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