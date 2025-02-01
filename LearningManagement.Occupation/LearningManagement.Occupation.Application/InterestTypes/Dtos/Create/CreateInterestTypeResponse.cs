namespace LearningManagement.Occupation.Application.InterestTypes.Dtos.Create;

public record CreateInterestTypeResponse(
    long Id,
    string? Title,
    long Code,
    string Description
);