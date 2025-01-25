namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

public sealed record OrganizationTypeSearchRequest(
    string? Title,
    long? Code,
    string? Description
);