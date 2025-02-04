namespace LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;

public record OccupationJobZoneDto(
    Guid Id,
    string? Description,
    Guid JobZoneId,
    Guid OccupationId,
    OccupationJobZoneDto.OccupationResponse Occupation) {
    public record OccupationResponse(
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
        Guid JobClassificationId);
}