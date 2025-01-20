using LearningManagement.Occupation.Application.Departments.Dto;

namespace LearningManagement.Occupation.Application.Companies.Dto;

public record CompanyDto(
    long Id,
    long? TypeId,
    string Title,
    bool IsViewable,
    bool IsApproved,
    long CertificateCode,
    string Description,
    string LogoUrl,
    List<DepartmentDto> Departments
);