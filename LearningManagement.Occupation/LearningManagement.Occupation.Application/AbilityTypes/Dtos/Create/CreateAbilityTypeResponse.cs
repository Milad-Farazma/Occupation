namespace LearningManagement.Occupation.Application.AbilityTypes.Dtos.Create;

public record CreateAbilityTypeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);