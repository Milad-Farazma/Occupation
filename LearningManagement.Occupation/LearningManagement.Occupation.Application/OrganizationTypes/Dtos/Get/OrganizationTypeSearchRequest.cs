namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;

public sealed record OrganizationTypeSearchRequest(
    string? Title,
    long? Code,
    string? Description
);