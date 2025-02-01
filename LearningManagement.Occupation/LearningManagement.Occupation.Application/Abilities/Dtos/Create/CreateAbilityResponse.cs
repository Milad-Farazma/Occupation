namespace LearningManagement.Occupation.Application.Abilities.Dtos.Create;

public record CreateAbilityResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);