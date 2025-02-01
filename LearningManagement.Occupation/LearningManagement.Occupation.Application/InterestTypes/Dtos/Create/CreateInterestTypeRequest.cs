namespace LearningManagement.Occupation.Application.InterestTypes.Dtos.Create;

public record CreateInterestTypeRequest(
    string? Title,
    long Code,
    string Description
);