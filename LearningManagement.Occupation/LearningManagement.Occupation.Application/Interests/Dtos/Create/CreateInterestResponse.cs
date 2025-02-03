namespace LearningManagement.Occupation.Application.Interests.Dtos.Create;

public record CreateInterestResponse(
    Guid Id,
    string? Title,
    long Code,
    string Description,
    long InterestedTypeId
);