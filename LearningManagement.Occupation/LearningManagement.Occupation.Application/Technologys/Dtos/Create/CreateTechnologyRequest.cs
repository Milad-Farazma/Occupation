namespace LearningManagement.Occupation.Application.Technologys.Dtos.Create;

public record CreateTechnologyRequest(
    string? Title,
    long Code,
    string? Description
);