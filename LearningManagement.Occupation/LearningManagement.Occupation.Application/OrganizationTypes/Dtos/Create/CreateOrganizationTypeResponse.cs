namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Create;

public record CreateOrganizationTypeResponse(Guid Id, string? Title, long Code, string? Description);