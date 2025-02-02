namespace LearningManagement.Occupation.Application.TechnologyTypes.Dtos;

public record UpdateTechnologyTypeRequest(
    string? Title,
    long Code,
    string? Description
);