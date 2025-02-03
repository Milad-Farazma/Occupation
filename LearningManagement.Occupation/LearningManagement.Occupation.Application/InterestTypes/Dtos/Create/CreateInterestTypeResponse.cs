namespace LearningManagement.Occupation.Application.InterestTypes.Dtos.Create;

public record CreateInterestTypeResponse(
    Guid Id,
    string? Title,
    long Code,
    string Description
);