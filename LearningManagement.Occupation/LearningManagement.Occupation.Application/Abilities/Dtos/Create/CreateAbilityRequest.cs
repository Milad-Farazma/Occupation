namespace LearningManagement.Occupation.Application.Abilities.Dtos.Create;

public record CreateAbilityRequest(
    string? Title,
    long Code,
    string? Description
);