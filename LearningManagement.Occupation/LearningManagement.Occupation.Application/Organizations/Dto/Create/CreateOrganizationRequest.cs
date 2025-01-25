namespace LearningManagement.Occupation.Application.Organizations.Dto.Create;

public record CreateOrganizationRequest(
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
    bool IsPublic,
    long OrganizationTypeId
);