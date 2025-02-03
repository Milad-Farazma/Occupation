namespace LearningManagement.Occupation.Application.Technologys.Dtos.Create;

public record CreateTechnologyResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);