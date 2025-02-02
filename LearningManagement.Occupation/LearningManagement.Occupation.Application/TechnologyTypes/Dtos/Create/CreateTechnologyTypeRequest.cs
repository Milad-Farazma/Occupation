namespace LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Create;

public record CreateTechnologyTypeRequest(
    string? Title,
    long Code,
    string? Description
);