namespace LearningManagement.Occupation.Application.Interests.Dtos.Create;

public record CreateInterestRequest(
    string? Title,
    long Code,
    string Description,
    long InterestedTypeId
);