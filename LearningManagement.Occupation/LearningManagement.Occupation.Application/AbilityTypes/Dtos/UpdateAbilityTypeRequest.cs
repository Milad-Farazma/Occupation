namespace LearningManagement.Occupation.Application.AbilityTypes.Dtos;

public record UpdateAbilityTypeRequest(
    string? Title,
    long Code,
    string? Description
);