namespace LearningManagement.Occupation.Application.Occupations.Dtos.Get;

public record OccupationDto(
    Guid Id,
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
    Guid JobOutlookId,
    Guid JobClassificationId);