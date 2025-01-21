using LearningManagement.Occupation.Application.Departments.Dto;

namespace LearningManagement.Occupation.Application.Organizations.Dto;

public record OrganizationDto(
    long Id,
    long? TypeId,
    string Title,
    bool IsViewable,
    bool IsApproved,
    long CertificateCode,
    string Description,
    string LogoUrl,
    IEnumerable<DepartmentDto> Departments
);