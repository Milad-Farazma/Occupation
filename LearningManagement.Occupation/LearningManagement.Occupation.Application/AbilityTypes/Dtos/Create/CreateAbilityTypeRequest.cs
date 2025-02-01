namespace LearningManagement.Occupation.Application.AbilityTypes.Dtos.Create;

public record CreateAbilityTypeRequest(
    string? Title,
    long Code,
    string? Description
);