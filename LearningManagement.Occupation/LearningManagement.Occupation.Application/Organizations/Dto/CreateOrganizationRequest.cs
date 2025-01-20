namespace LearningManagement.Occupation.Application.Organizations.Dto;

public record CreateOrganizationRequest(
    long? TypeId,
    string Title,
    bool IsViewable,
    bool IsApproved,
    long CertificateCode,
    string Description,
    string LogoUrl
);