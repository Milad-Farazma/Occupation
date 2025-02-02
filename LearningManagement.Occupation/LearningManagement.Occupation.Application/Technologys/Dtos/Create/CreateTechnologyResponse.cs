namespace LearningManagement.Occupation.Application.Technologys.Dtos.Create;

public record CreateTechnologyResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);