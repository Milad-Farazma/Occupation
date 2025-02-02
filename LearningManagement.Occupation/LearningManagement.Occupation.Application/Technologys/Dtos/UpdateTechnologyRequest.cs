namespace LearningManagement.Occupation.Application.Technologys.Dtos;

public record UpdateTechnologyRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);