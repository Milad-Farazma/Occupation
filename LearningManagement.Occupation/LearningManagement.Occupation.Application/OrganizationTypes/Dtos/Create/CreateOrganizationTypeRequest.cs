namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Create;

public record CreateOrganizationTypeRequest(
    string? Title,
    long Code,
    string? Description
);