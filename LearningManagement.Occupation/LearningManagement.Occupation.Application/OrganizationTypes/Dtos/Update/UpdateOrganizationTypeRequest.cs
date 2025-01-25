namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Update;

public record UpdateOrganizationTypeRequest(
    string Title,
    long Code,
    string Description
);