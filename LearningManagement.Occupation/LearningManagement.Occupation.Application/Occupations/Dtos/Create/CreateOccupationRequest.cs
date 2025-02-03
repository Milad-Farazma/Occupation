namespace LearningManagement.Occupation.Application.Occupations.Dtos.Create;

public record CreateOccupationRequest(
    string? Title,
    long Code,
    string? Description,
    string? BriefActivities,
    string? BannerImage,
    string? VideoDescription,
    string? BriefPersonality,
    decimal? MinimumSalary,
    decimal? MaximumSalary,
    decimal? ModeSalary,
    int JobOutlookId,
    int JobClassificationId
);