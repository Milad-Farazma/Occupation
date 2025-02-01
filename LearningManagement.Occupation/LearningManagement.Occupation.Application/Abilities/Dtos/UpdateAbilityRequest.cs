namespace LearningManagement.Occupation.Application.Abilities.Dtos;

public record UpdateAbilityRequest(
    string? Title,
    long Code,
    string? Description
);