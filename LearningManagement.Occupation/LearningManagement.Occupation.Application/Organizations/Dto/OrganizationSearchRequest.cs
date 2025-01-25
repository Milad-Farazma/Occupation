namespace LearningManagement.Occupation.Application.Organizations.Dto;

public sealed record OrganizationSearchRequest(
    string? Title = null,
    long? Code = null,
    int? ProvinceId = null,
    string? ProvinceTitle = null,
    int? CityId = null,
    string? CityTitle = null,
    int? OrganizationTypeId = null,
    string? CertificateCode = null,
    string? WebsiteUrl = null,
    string? Email = null,
    bool? Accepted = null,
    DateOnly? AcceptedDate = null,
    bool? IsPublic = null
);