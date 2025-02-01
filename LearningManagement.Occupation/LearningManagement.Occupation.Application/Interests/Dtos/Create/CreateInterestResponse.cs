namespace LearningManagement.Occupation.Application.Interests.Dtos.Create;

public record CreateInterestResponse(
    long Id,
    string? Title,
    long Code,
    string Description,
    long InterestedTypeId
);