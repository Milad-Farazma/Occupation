namespace LearningManagement.Occupation.Application.Organizations.Dto.Update;

public record UpdateOrganizationRequest(
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
    bool IsPublic,
    long OrganizationTypeId
);