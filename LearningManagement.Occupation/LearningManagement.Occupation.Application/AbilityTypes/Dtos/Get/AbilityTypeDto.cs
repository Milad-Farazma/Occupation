namespace LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;

public record AbilityTypeDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<AbilityTypeDto.AbilityResponse> Abilities) {
    public record AbilityResponse(string? Title, long Code, string? Description);
}