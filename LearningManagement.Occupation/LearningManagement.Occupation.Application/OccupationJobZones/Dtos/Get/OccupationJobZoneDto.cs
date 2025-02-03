namespace LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;

public record OccupationJobZoneDto(
    long Id,
    string? Description,
    int JobZoneId,
    int OccupationId,
    OccupationJobZoneDto.OccupationResponse Occupation) {
    public record OccupationResponse(
        long Id,
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
        int JobClassificationId);
}