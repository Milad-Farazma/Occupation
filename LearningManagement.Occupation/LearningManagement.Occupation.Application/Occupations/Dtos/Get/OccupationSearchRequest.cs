namespace LearningManagement.Occupation.Application.Occupations.Dtos.Get;

public sealed record OccupationSearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null,
    string? BriefActivities = null,
    string? VideoDescription = null,
    string? BriefPersonality = null
);