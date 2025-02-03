namespace LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;

public record TechnologyTypeDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<TechnologyTypeDto.TechnologyResponse> Technologies) {
    public record TechnologyResponse(string? Title, long Code, string? Description);
}