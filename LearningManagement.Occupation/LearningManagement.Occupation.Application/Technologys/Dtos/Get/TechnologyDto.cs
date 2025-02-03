namespace LearningManagement.Occupation.Application.Technologys.Dtos.Get;

public record TechnologyDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    TechnologyDto.TechnologyTypeResponse TechnologyType) {
    public record TechnologyTypeResponse(string? Title, long Code, string? Description);
}