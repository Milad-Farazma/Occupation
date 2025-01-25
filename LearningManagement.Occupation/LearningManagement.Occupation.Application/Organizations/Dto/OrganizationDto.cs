using LearningManagement.Occupation.Application.Departments.Dto;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

namespace LearningManagement.Occupation.Application.Organizations.Dto;

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
    bool IsPublic,
    ICollection<DepartmentDto> Departments,
    OrganizationTypeDto OrganizationType
);