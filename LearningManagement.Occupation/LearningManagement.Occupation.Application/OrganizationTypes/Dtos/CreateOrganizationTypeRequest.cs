namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

public record CreateOrganizationTypeRequest(
    string Title,
    long Code,
    string Description
);