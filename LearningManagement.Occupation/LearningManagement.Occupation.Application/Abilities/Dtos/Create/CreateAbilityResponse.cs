namespace LearningManagement.Occupation.Application.Abilities.Dtos.Create;

public record CreateAbilityResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    Guid AbilityTypeId
);