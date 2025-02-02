namespace LearningManagement.Occupation.Application.Technologys.Dtos.Get;

public record TechnologyDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    TechnologyDto.TechnologyTypeResponse TechnologyType) {
    public record TechnologyTypeResponse(string? Title, long Code, string? Description);
}