namespace LearningManagement.Occupation.Application.Interests.Dtos.Get;

public record InterestDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    InterestDto.InterestTypeResponse InterestType) {
    public record InterestTypeResponse(string? Title, string? Description);
}