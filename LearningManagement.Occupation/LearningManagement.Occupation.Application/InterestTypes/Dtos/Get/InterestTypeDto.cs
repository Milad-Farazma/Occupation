namespace LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;

public record InterestTypeDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<InterestTypeDto.InterestResponse> Interests) {
    public record InterestResponse(string? Title, string? Description);
}