namespace LearningManagement.Occupation.Application.AbilityTypes.Dtos.Create;

public record CreateAbilityTypeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);