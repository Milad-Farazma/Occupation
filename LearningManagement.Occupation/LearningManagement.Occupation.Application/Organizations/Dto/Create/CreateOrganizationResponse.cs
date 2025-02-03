namespace LearningManagement.Occupation.Application.Organizations.Dto.Create;

public record CreateOrganizationResponse(
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
    bool IsPublic);