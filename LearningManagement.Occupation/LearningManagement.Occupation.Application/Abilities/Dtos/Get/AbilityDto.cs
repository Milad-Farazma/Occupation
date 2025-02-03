namespace LearningManagement.Occupation.Application.Abilities.Dtos.Get;

public record AbilityDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    AbilityDto.AbilityTypeResponse AbilityType) {
    public record AbilityTypeResponse(string? Title, long Code, string? Description);
}