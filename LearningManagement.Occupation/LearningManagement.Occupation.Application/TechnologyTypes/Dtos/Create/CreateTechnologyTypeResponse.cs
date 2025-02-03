namespace LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Create;

public record CreateTechnologyTypeResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);