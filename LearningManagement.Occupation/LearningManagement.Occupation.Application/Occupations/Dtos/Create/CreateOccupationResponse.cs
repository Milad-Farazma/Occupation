namespace LearningManagement.Occupation.Application.Occupations.Dtos.Create;

public record CreateOccupationResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    string? BriefActivities,
    string? BannerUrl,
    string? IntroductionVideoUrl,
    string? BriefPersonality,
    decimal? MinimumSalary,
    decimal? MaximumSalary,
    decimal? ModeSalary,
    Guid JobOutlookId,
    Guid JobClassificationId
);