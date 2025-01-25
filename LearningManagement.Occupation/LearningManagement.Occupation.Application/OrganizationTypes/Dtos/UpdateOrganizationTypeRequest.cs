namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

public record UpdateOrganizationTypeRequest(
    string Title,
    long Code,
    string Description
);