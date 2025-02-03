namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

public record OrganizationTypeDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<OrganizationTypeDto.OrgDto> Organizations) {
    public record OrgDto(
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
        bool IsPublic
    );
}