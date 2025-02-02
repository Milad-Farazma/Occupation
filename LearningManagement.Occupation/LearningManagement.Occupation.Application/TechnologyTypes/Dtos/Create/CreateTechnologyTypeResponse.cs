namespace LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Create;

public record CreateTechnologyTypeResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);